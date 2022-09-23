using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Services.Interfaces;
using System.Collections.Generic;
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

        /// <summary>
        /// Returns a list of the authors responsible for the Middle Earth books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((typeof(ICollection<Resources.DataTransferObjects.Response.Author>)), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAuthors()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving authors through GetAuthors");

            var authors = await _authorService.GetAuthors();

            _logger.LogInformation($"{ComponentName} - Retrieved {authors.Count} authors through GetAuthors");

            return Ok(authors);
        }

        /// <summary>
        /// Returns a detailed version of an author by its id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType((typeof(Resources.DataTransferObjects.Response.Author)), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            _logger.LogInformation($"{ComponentName} - Retrieving author through GetAuthorById with the following id: {id}");

            var author = await _authorService.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"{ComponentName} - Retrieved author with id {id} through GetAuthorById");

            return Ok(author);
        }
    }
}