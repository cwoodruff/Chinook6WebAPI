using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public class PlaylistApiModel : BaseApiModel, IConvertModel<Playlist>
{
    public string? Name { get; set; }

    public IList<TrackApiModel>? Tracks { get; set; }

    public Playlist Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}