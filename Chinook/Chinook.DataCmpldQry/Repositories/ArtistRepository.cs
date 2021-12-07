using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class ArtistRepository : CpmldQryRepository<Artist>, IArtistRepository
{
    public ArtistRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<Artist>> IRepository<Artist>.GetAll() => await _context.GetAllArtists().ToListAsync();

    async Task<Artist?> IRepository<Artist>.GetById(int id) => await _context.GetArtist(id);
}