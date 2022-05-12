using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IAlbumRepository : IRepository<Album>, IDisposable
{
    Task<List<Album>> GetByArtistId(int id);
}