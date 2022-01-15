using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class BookWriter : Profile
    {
        public BookWriter()
        {
            CreateMap<Data.Models.BookAuthor, DataTransferObjects.Response.BookWriter>()
                .ForMember(destination => destination.Name,
                    map => map.MapFrom(
                        (source, destination) => source.Author.Name))
                .ForMember(destination => destination.Role,
                    map => map.MapFrom(
                        (source, destination) => source.Role.AuthorRole));
        }
    }
}