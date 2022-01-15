using MiddleEarthAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddleEarthAPI.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetBooks();

        Task<Book> GetBookById(int id);
    }
}