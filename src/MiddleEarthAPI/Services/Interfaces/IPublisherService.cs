using MiddleEarthAPI.Resources.DataTransferObjects.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<DetailedPublisher> GetPublisherById(int id);

        Task<List<Publisher>> GetPublishers();
    }
}