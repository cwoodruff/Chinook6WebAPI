using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Data.Repositories;

public class PlaylistRepository : BaseRepository<Playlist>, IDisposable, IPlaylistRepository
{
    public PlaylistRepository(ChinookContext context) : base(context)
    {
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Playlist>> GetByTrackId(int id)
    {
        return await _context.Playlists
            .Where(c => c.Tracks.Any(o => o.Id == id))
            .AsNoTrackingWithIdentityResolution().ToListAsync();
    }
}