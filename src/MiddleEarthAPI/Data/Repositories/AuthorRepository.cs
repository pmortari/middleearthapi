using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Data.Models;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private const string ComponentName = "[AuthorRepository]";
        private readonly MiddleEarthDataContext _middleEarthDataContext;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(ILogger<AuthorRepository> logger,
                                MiddleEarthDataContext middleEarthDataContext)
        {
            _logger = logger;
            _middleEarthDataContext = middleEarthDataContext;
        }

        public Task<Author> GetAuthorById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Author>> GetAuthors()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving authors through GetAuthors");

            var authors = await _middleEarthDataContext.Author.ToListAsync();

            _logger.LogInformation($"{ComponentName} - Retrieved {authors.Count} books through GetAuthors");

            return authors;
        }
    }
}