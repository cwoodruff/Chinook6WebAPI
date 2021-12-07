using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class AlbumRepository : CpmldQryRepository<Album>, IAlbumRepository
{
    public AlbumRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<Album>> IRepository<Album>.GetAll() => await _context.GetAllAlbums().ToListAsync();

    async Task<Album> IRepository<Album>.GetById(int id) => await _context.GetAlbum(id);

    async Task<List<Album>> IAlbumRepository.GetByArtistId(int id) => await _context.GetAlbumsByArtistId(id).ToListAsync();
}