using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Data.Models;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Data.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private const string ComponentName = "[PublisherRepository]";
        private readonly MiddleEarthDataContext _middleEarthDataContext;
        private readonly ILogger<PublisherRepository> _logger;

        public PublisherRepository(ILogger<PublisherRepository> logger,
                                MiddleEarthDataContext middleEarthDataContext)
        {
            _logger = logger;
            _middleEarthDataContext = middleEarthDataContext;
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            _logger.LogInformation($"{ComponentName} - Retrieving publisher through GetPublisherById with the following id: {id}.");

            var publisher = await _middleEarthDataContext.Publisher
                .FirstOrDefaultAsync(p => p.PublisherId == id);

            _logger.LogInformation($"{ComponentName} - Retrieved publisher through GetPublisherById with the following id: {id}.");

            return publisher;
        }

        public async Task<ICollection<Publisher>> GetPublishers()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving publishers through GetPublishers");

            var publishers = await _middleEarthDataContext.Publisher.ToListAsync();

            _logger.LogInformation($"{ComponentName} - Retrieved {publishers.Count} publishers through GetPublishers");

            return publishers;
        }
    }
}
