using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public class MediaTypeApiModel : BaseApiModel, IConvertModel<MediaType>
{
    public string? Name { get; set; }

    public IList<TrackApiModel>? Tracks { get; set; }

    public MediaType Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}