using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class Book : Profile
    {
        public Book()
        {
            CreateMap<Data.Models.Book, DataTransferObjects.Response.Book>();
        }
    }
}