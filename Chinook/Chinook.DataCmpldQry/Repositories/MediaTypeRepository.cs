using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class MediaTypeRepository : CpmldQryRepository<MediaType>, IMediaTypeRepository
{
    public MediaTypeRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<MediaType>> IRepository<MediaType>.GetAll() => await _context.GetAllMediaTypes().ToListAsync();

    async Task<MediaType?> IRepository<MediaType>.GetById(int id) => await _context.GetMediaType(id);
}