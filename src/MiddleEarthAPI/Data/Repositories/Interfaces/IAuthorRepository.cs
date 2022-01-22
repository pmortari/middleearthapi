using MiddleEarthAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Data.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<ICollection<Author>> GetAuthors();

        Task<Author> GetAuthorById(int id);
    }
}