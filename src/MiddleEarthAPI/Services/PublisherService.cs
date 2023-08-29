using AutoMapper;
using Microsoft.Extensions.Logging;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using MiddleEarthAPI.Resources.DataTransferObjects.Response;
using MiddleEarthAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private const string ComponentName = "[PublisherService]";
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PublisherService(ILogger<PublisherService> logger,
                             IPublisherRepository publisherRepository,
                             IMapper mapper)
        {
            _logger = logger;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<DetailedPublisher> GetPublisherById(int id)
        {
            _logger.LogInformation($"{ComponentName} - Retrieving publisher through GetPublisherById with the following id: {id}.");

            var publisher = await _publisherRepository.GetPublisherById(id);

            if (publisher == null)
            {
                _logger.LogInformation($"{ComponentName} - No publisher found with id {id} through GetPublisherById.");
                return null;
            }

            _logger.LogInformation($"{ComponentName} - Preparing to map Publisher Id: {id}.");

            var detailedPublisher = _mapper.Map<DetailedPublisher>(publisher);

            _logger.LogInformation($"{ComponentName} - Publisher Id: {id} successfully mapped.");

            return detailedPublisher;
        }

        public async Task<ICollection<Publisher>> GetPublishers()
        {
            _logger.LogInformation($"{ComponentName} - Retrieving publishers through GetPublishers");

            var publishers = await _publisherRepository.GetPublishers();

            _logger.LogInformation($"{ComponentName} - Retrieved {publishers.Count} publishers through GetPublishers");

            _logger.LogInformation($"{ComponentName} - Preparing to map publishers.");

            var mappedPublishers = _mapper.Map<ICollection<Publisher>>(publishers);

            _logger.LogInformation($"{ComponentName} - Publishers successfully mapped.");

            return mappedPublishers;
        }
    }
}