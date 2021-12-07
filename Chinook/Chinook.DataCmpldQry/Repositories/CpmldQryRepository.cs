using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataCmpldQry.Repositories;

public class CpmldQryRepository<T> : ICpmldQryRepository<T> where T : BaseEntity
{
    protected ChinookContext _context;

    protected CpmldQryRepository(ChinookContext context)
    {
        _context = context;
    }
    
    public void Dispose() => _context.Dispose();
    
    public async Task<bool> EntityExists(int id) =>
        await _context.Set<T>().AnyAsync(a => a.Id == id);

    public async Task<T> Add(T entity)
    {
        // await Context.AddAsync(entity);
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