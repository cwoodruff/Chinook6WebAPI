using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;

namespace Chinook.Domain.Entities;

public sealed class Playlist : BaseEntity, IConvertModel<PlaylistApiModel>
{
    public string? Name { get; set; }


    public ICollection<Track>? Tracks { get; set; }

    public PlaylistApiModel Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}