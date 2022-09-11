using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataPostgres.Repositories;

public class ArtistRepository : BaseRepository<Artist>, IDisposable, IArtistRepository
{
    public ArtistRepository(ChinookPostgresContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();
}