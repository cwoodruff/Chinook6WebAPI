using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IPlaylistRepository : IRepository<Playlist>, IDisposable
{
    Task<List<Playlist>> GetByTrackId(int id);
}