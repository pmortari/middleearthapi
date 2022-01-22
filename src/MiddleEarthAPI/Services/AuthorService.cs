using AutoMapper;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using MiddleEarthAPI.Resources.DataTransferObjects.Response;
using MiddleEarthAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private const string ComponentName = "[AuthorService]";
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AuthorService(ILogger<AuthorService> logger,
                             IAuthorRepository authorRepository,
                             IMapper mapper)
        {
            _logger = logger;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public Task<Author> GetAuthorById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Author>> GetAuthors()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving authors through GetAuthors");

            var authors = await _authorRepository.GetAuthors();

            _logger.LogInformation($"{ComponentName} - Retrieved {authors.Count} authors through GetAuthors");

            _logger.LogInformation($"{ComponentName} - Preparing to map authors.");

            var mappedAuthors = _mapper.Map<ICollection<Author>>(authors);

            _logger.LogInformation($"{ComponentName} - Authors successfully mapped.");

            return mappedAuthors;
        }
    }
}