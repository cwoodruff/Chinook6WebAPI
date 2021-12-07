using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataCmpldQry.Repositories;

public class TrackRepository : CpmldQryRepository<Track>, ITrackRepository
{
    public TrackRepository(ChinookContext context) : base(context)
    {
    }

    async Task<List<Track>> IRepository<Track>.GetAll() => await _context.GetAllTracks().ToListAsync();

    async Task<Track?> IRepository<Track>.GetById(int id) => await _context.GetTrack(id);

    public async Task<List<Track>> GetByAlbumId(int id) => await _context.GetTracksByAlbumId(id).ToListAsync();

    public async Task<List<Track>> GetByGenreId(int id) => await _context.GetTracksByGenreId(id).ToListAsync();
    
    public async Task<List<Track>> GetByMediaTypeId(int id) => await _context.GetTracksByMediaTypeId(id).ToListAsync();
        
    public async Task<List<Track>> GetByPlaylistId(int id) => await _context.GetTracksByPlaylistId(id).ToListAsync();

    public async Task<List<Track>> GetByArtistId(int id) => await _context.GetTracksByArtistId(id).ToListAsync();

    public async Task<List<Track>> GetByInvoiceId(int id) => await _context.GetTracksByInvoiceId(id).ToListAsync();
}