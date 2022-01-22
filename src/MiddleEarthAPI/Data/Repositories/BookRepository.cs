using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Data.Models;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private const string ComponentName = "[BookRepository]";
        private readonly MiddleEarthDataContext _middleEarthDataContext;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(ILogger<BookRepository> logger,
                              MiddleEarthDataContext middleEarthDataContext)
        {
            _logger = logger;
            _middleEarthDataContext = middleEarthDataContext;
        }

        public async Task<Book> GetBookById(int id)
        {
            _logger.LogInformation($"{ComponentName} - Retrieving book through GetBookById with the following id: {id}.");

            var book = await _middleEarthDataContext.Book
                .Include(p => p.Authors)
                .ThenInclude(p => p.Author)
                .Include(p => p.Authors)
                .ThenInclude(p => p.Role)
                .Include(p => p.Publisher)
                .FirstOrDefaultAsync(p => p.BookId == id);

            _logger.LogInformation($"{ComponentName} - Retrieved book through GetBookById with the following id: {id}.");

            return book;
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving books through GetBooks");

            var books = await _middleEarthDataContext.Book.ToListAsync();

            _logger.LogInformation($"{ComponentName} - Retrieved {books.Count} books through GetBooks");

            return books;
        }
    }
}