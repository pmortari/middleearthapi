using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<ICollection<Resources.DataTransferObjects.Response.Author>> GetAuthors();

        Task<Resources.DataTransferObjects.Response.Author> GetAuthorById(int id);
    }
}