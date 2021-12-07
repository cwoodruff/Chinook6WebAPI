using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.Data.Repositories;

public class ArtistRepository : BaseRepository<Artist>, IDisposable, IArtistRepository
{
    public ArtistRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();
}