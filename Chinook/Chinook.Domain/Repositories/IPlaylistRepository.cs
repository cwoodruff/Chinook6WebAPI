using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Repositories;

public interface IPlaylistRepository : IRepository<Playlist>, IDisposable
{
    Task<List<Playlist>> GetByTrackId(int id);
}