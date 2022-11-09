using MiddleEarthAPI.Resources.DataTransferObjects.Response;
using MiddleEarthAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Services
{
    public class PublisherService : IPublisherService
    {
        public Task<DetailedPublisher> GetPublisherById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Publisher>> GetPublishers()
        {
            throw new System.NotImplementedException();
        }
    }
}