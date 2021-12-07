using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class GenreRepository : CpmldQryRepository<Genre>, IGenreRepository
{
    public GenreRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<Genre>> IRepository<Genre>.GetAll() => await _context.GetAllGenres().ToListAsync();

    async Task<Genre?> IRepository<Genre>.GetById(int id) => await _context.GetGenre(id);
}