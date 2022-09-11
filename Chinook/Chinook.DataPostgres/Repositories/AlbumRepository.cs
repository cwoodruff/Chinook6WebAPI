using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataPostgres.Repositories;

public class AlbumRepository : BaseRepository<Album>, IAlbumRepository, IDisposable
{
    public AlbumRepository(ChinookPostgresContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Album>> GetByArtistId(int id) =>
        await _context.Albums.Where(a => a.ArtistId == id).AsNoTrackingWithIdentityResolution().ToListAsync();
}