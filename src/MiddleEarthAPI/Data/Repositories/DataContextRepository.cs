using Microsoft.Extensions.Options;
using MiddleEarthAPI.Data.Models;
using MiddleEarthAPI.Data.Repositories.Interfaces;
using MiddleEarthAPI.Resources;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MiddleEarthAPI.Data.Repositories
{
    public class DataContextRepository : IDataContextRepository
    {
        private readonly MiddleEarthDataContext _middleEarthDataContext;
        private readonly Settings _settings;

        public DataContextRepository(MiddleEarthDataContext middleEarthDataContext,
                                     IOptions<Settings> settings)
        {
            _middleEarthDataContext = middleEarthDataContext;
            _settings = settings.Value;
        }

        public void LoadInMemoryData()
        {
            LoadData<Publisher>(_settings.PublishersFile);
            LoadData<Role>(_settings.RolesFile);
            LoadData<Author>(_settings.AuthorsFile);
            LoadData<Book>(_settings.BooksFile);
            LoadData<BookAuthor>(_settings.BookAuthorsFile);

            SaveInMemoryEntities();
        }

        private void LoadData<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);

            var data = reader.ReadToEnd();

            var serializedData = JsonSerializer.Deserialize<List<T>>(data,
                                                                     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //TODO: Review this portion of code in the future - Testing purposes
            serializedData.ForEach(p => _middleEarthDataContext.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Added);
        }

        private void SaveInMemoryEntities()
        {
            _middleEarthDataContext.SaveChanges();
        }
    }
}