using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;

namespace Chinook.Domain.Entities;

public sealed class Album : BaseEntity, IConvertModel<AlbumApiModel>
{
    public Album()
    {
        Tracks = new HashSet<Track>();
    }

    public string? Title { get; set; }
    public int ArtistId { get; set; }

    public Artist? Artist { get; set; }
    public ICollection<Track>? Tracks { get; set; }

    public AlbumApiModel Convert() =>
        new()
        {
            Id = Id,
            ArtistId = ArtistId,
            Title = Title
        };
}