using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AuthorController : ControllerBase
    {
        private const string ComponentName = "[AuthorController]";
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;

        public AuthorController(ILogger<AuthorController> logger,
                                IAuthorService authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAuthors()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving authors through GetAuthors");

            var authors = await _authorService.GetAuthors();

            _logger.LogInformation($"{ComponentName} - Retrieved {authors.Count} authors through GetAuthors");

            return Ok(authors);
        }
    }
}