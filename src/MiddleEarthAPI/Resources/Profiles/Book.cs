using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class Book : Profile
    {
        public Book()
        {
            CreateMap<Data.Models.Book, DataTransferObjects.Response.Book>()
                .ForMember(destination => destination.Publisher,
                    map => map.MapFrom(
                        (source, destination) => source?.Publisher?.Name));
            CreateMap<Data.Models.BookAuthor, DataTransferObjects.Response.BookWriter>();
        }
    }
}