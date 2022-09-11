using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataPostgres.Repositories;

public class GenreRepository : BaseRepository<Genre>, IDisposable, IGenreRepository
{
    public GenreRepository(ChinookPostgresContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();
}