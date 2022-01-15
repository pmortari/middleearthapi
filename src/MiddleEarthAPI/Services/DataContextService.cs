using MiddleEarthAPI.Data.Repositories.Interfaces;
using MiddleEarthAPI.Services.Interfaces;

namespace MiddleEarthAPI.Services
{
    public class DataContextService : IDataContextService
    {
        private readonly IDataContextRepository _dataContextRepository;

        public DataContextService(IDataContextRepository dataContextRepository)
        {
            _dataContextRepository = dataContextRepository;
        }

        public void LoadInMemoryData()
        {
            _dataContextRepository.LoadInMemoryData();
        }
    }
}