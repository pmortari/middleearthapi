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
    public class BookController : ControllerBase
    {
        private const string _componentName = "[BookControler]";
        private readonly IBookService _bookService;
        private readonly ILogger _logger;

        public BookController(ILogger<BookController> logger,
                              IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Returns a list of the amazing books from the Middle Earth
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooks()
        {
            _logger.LogInformation($"{_componentName} - Retrieving books through GetBooks");

            var books = await _bookService.GetBooks();

            _logger.LogInformation($"{_componentName} - Retrieved {books.Count} books through GetBooks");

            return Ok(books);
        }

        /// <summary>
        /// Returns a detailed version of a book by its id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookById(int id)
        {
            _logger.LogInformation($"{_componentName} - Retrieving book through GetBookById with the following id: {id}");

            var book = await _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"{_componentName} - Retrieved book with id {id} through GetBookById");

            return Ok(book);
        }
    }
}