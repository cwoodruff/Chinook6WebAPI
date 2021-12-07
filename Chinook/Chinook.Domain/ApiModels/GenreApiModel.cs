using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public class GenreApiModel : BaseApiModel, IConvertModel<Genre>
{
    public string? Name { get; set; }

    public IList<TrackApiModel>? Tracks { get; set; }

    public Genre Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}