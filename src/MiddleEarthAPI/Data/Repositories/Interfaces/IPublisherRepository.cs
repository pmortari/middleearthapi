using MiddleEarthAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Data.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        Task<ICollection<Publisher>> GetPublishers();

        Task<Publisher> GetPublisherById(int id);
    }
}
