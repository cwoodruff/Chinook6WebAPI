using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class PlaylistRepository : CpmldQryRepository<Playlist>, IPlaylistRepository
{
    public PlaylistRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<Playlist>> IRepository<Playlist>.GetAll() => await _context.GetAllPlaylists().ToListAsync();

    async Task<Playlist?> IRepository<Playlist>.GetById(int id) => await _context.GetPlaylist(id);
    
    public async Task<List<Playlist>> GetByTrackId(int id) => await _context.GetPlaylistsByTrackId(id).ToListAsync();
}