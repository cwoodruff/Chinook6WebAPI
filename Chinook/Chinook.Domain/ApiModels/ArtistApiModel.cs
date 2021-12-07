using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public class ArtistApiModel : BaseApiModel, IConvertModel<Artist>
{
    public string? Name { get; set; }

    public IList<AlbumApiModel>? Albums { get; set; }

    public Artist Convert() =>
        new()
        {
            Id = Id,
            Name = Name ?? string.Empty
        };
}