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
        private const string _componentName = "[BookService]";
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BookService(IBookRepository bookRepository,
                           IMapper mapper,
                           ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Book> GetBookById(int id)
        {
            _logger.LogInformation($"{_componentName} - Retrieving book through GetBookById with the following id: {id}.");

            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                _logger.LogInformation($"{_componentName} - No book found with id {id} through GetBookById.");
                return null;
            }

            _logger.LogInformation($"{_componentName} - Preparing to map Book Id: {id}.");

            var mappedBook = _mapper.Map<Book>(book);

            _logger.LogInformation($"{_componentName} - Book Id: {id} successfully mapped.");

            return mappedBook;
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            _logger.LogInformation($"{_componentName} - Retrieving books through GetBooks");

            var books = await _bookRepository.GetBooks();

            _logger.LogInformation($"{_componentName} - Retrieved {books.Count} books through GetBooks");

            _logger.LogInformation($"{_componentName} - Preparing to map books.");

            var mappedBooks = _mapper.Map<ICollection<Book>>(books);

            _logger.LogInformation($"{_componentName} - Books successfully mapped.");

            return mappedBooks;
        }
    }
}