using AutoMapper;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using MiddleEarthAPI.Resources.DataTransferObjects.Response;
using MiddleEarthAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Services
{
    public class BookService : IBookService
    {
        private const string ComponentName = "[BookService]";
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BookService(ILogger<BookService> logger,
                           IBookRepository bookRepository,
                           IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<DetailedBook> GetBookById(int id)
        {
            _logger.LogInformation($"{ComponentName} - Retrieving book through GetBookById with the following id: {id}.");

            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                _logger.LogInformation($"{ComponentName} - No book found with id {id} through GetBookById.");
                return null;
            }

            _logger.LogInformation($"{ComponentName} - Preparing to map Book Id: {id}.");

            var mappedBook = _mapper.Map<DetailedBook>(book);

            _logger.LogInformation($"{ComponentName} - Book Id: {id} successfully mapped.");

            return mappedBook;
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving books through GetBooks");

            var books = await _bookRepository.GetBooks();

            _logger.LogInformation($"{ComponentName} - Retrieved {books.Count} books through GetBooks");

            _logger.LogInformation($"{ComponentName} - Preparing to map books.");

            var mappedBooks = _mapper.Map<ICollection<Book>>(books);

            _logger.LogInformation($"{ComponentName} - Books successfully mapped.");

            return mappedBooks;
        }
    }
}