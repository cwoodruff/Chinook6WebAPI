namespace Chinook.Domain.Exceptions;

public class GenreProblemException : ProblemDetailsException
{
    public int GenreId { get; set; }

    public GenreProblemException(int status, string type, string title, string detail, string instance,
        int artistId)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}