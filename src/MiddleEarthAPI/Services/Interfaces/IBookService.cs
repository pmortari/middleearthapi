using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<ICollection<Resources.DataTransferObjects.Response.Book>> GetBooks();

        Task<Resources.DataTransferObjects.Response.DetailedBook> GetBookById(int id);
    }
}