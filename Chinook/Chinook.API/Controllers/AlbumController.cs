using System.Net;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Exceptions;
using Chinook.Domain.ProblemDetails;
using Chinook.Domain.Supervisor;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.API.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
[EnableCors("CorsPolicy")]
[ApiVersion("1.0")]
public class AlbumController : ControllerBase
{
    private readonly IChinookSupervisor _chinookSupervisor;
    private readonly ILogger<AlbumController> _logger;

    public AlbumController(IChinookSupervisor chinookSupervisor, ILogger<AlbumController> logger)
    {
        _chinookSupervisor = chinookSupervisor;
        _logger = logger;
    }

    [HttpGet]
    [Produces(typeof(List<AlbumApiModel>))]
    public async Task<ActionResult<List<AlbumApiModel>>> Get()
    {
        try
        {
            var albums = await _chinookSupervisor.GetAllAlbum();

            if (albums.Any())
            {
                return Ok(albums);
            }
            else
            {
                var problemDetails = new AlbumProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://example.com/api/Artist/not-found",
                    Title = "Could not find any artists",
                    Detail = "Something went wrong inside the ArtistController Get All action",
                    AlbumId = null,
                    Instance = HttpContext.Request.Path
                };
                _logger.LogError($"{problemDetails.Detail}");
                return new ObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json" },
                    StatusCode = 404,
                };
            }
        }
        catch (AlbumProblemException ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"{problemDetails.Detail}: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
        catch (Exception ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"Something went wrong inside the AlbumController Get All Album action: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
    }

    [HttpGet("{id}", Name = "GetAlbumById")]
    public async Task<ActionResult<AlbumApiModel>> Get(int id)
    {
        try
        {
            var album = await _chinookSupervisor.GetAlbumById(id);

            if (album != null)
            {
                return Ok(album);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound, "Album Not Found");
            }
        }
        catch (AlbumProblemException ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"{problemDetails.Detail}: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
    }

    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<ActionResult<AlbumApiModel>> Post([FromBody] AlbumApiModel input)
    {
        try
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Album is null");
            }
            else
            {
                return Ok(await _chinookSupervisor.AddAlbum(input));
            }
        }
        catch (ValidationException ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"Something went wrong inside the AlbumController Add Album action: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
        catch (AlbumProblemException ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"{problemDetails.Detail}: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
        catch (Exception ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"Something went wrong inside the AlbumController Add Album action: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<ActionResult<AlbumApiModel>> Put(int id, [FromBody] AlbumApiModel input)
    {
        try
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Album is null");
            }
            else
            {
                return Ok(await _chinookSupervisor.UpdateAlbum(input));
            }
        }
        catch (ValidationException ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"Something went wrong inside the AlbumController Update Album action: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
        catch (Exception ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"Something went wrong inside the AlbumController Update Album action: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _chinookSupervisor.DeleteAlbum(id));
        }
        catch (Exception ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"Something went wrong inside the AlbumController Delete action: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
    }

    [HttpGet("artist/{id}")]
    public async Task<ActionResult<List<AlbumApiModel>>> GetByArtistId(int id)
    {
        try
        {
            var albums = await _chinookSupervisor.GetAlbumByArtistId(id);

            if (albums.Any())
            {
                return Ok(albums);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No Albums Could Be Found for the Artist");
            }
        }
        catch (Exception ex)
        {
            var problemDetails = new AlbumProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                AlbumId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"Something went wrong inside the AlbumController Get By Artist action: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
    }
}