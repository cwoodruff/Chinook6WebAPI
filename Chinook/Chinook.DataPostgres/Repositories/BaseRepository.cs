using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataPostgres.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected ChinookPostgresContext _context;

    protected BaseRepository(ChinookPostgresContext context)
    {
        _context = context;
    }

    public async Task<bool> EntityExists(int id) =>
        await _context.Set<T>().AnyAsync(a => a.Id == id);

    public async Task<List<T>> GetAll() =>
        await _context.Set<T>().AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<T> GetById(int id) => await _context.Set<T>().SingleAsync(e => e.Id == id);

    public async Task<T> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Update(T entity)
    {
        if (!await EntityExists(entity.Id))
            return false;
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        if (!await EntityExists(id))
            return false;
        var toRemove = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(toRemove);
        await _context.SaveChangesAsync();
        return true;
    }
}