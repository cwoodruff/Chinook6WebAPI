using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;

namespace Chinook.Domain.Entities;

public sealed class Genre : BaseEntity, IConvertModel<GenreApiModel>
{
    public Genre()
    {
        Tracks = new HashSet<Track>();
    }

    public string? Name { get; set; }
    public ICollection<Track>? Tracks { get; set; }

    public GenreApiModel Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}