using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataPostgres.Repositories;

public class TrackRepository : BaseRepository<Track>, IDisposable, ITrackRepository
{
    public TrackRepository(ChinookPostgresContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Track>?> GetByAlbumId(int id) =>
        await _context.Tracks.Where(a => a.AlbumId == id).AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<List<Track>> GetByGenreId(int id) =>
        await _context.Tracks.Where(a => a.GenreId == id).AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<List<Track>> GetByMediaTypeId(int id) =>
        await _context.Tracks.Where(a => a.MediaTypeId == id).AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<List<Track>> GetByPlaylistId(int id) =>
        await _context.Playlists.Where(p => p.Id == id).SelectMany(p => p.Tracks)
            .AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<List<Track>> GetByArtistId(int id) =>
        await _context.Albums.Where(a => a.ArtistId == 5).SelectMany(t => t.Tracks)
            .AsNoTrackingWithIdentityResolution().ToListAsync();

    public async Task<List<Track>> GetByInvoiceId(int id) => await _context.Tracks
        .Where(c => c.InvoiceLines.Any(o => o.InvoiceId == id))
        .AsNoTrackingWithIdentityResolution().ToListAsync();
}