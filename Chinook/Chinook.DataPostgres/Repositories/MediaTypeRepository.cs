using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataPostgres.Repositories;

public class MediaTypeRepository : BaseRepository<MediaType>, IDisposable, IMediaTypeRepository
{
    public MediaTypeRepository(ChinookPostgresContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();
}