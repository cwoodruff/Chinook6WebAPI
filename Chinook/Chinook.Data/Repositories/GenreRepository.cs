using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.Data.Repositories;

public class GenreRepository : BaseRepository<Genre>, IDisposable, IGenreRepository
{
    public GenreRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();
}