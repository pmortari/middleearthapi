using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class DetailedBook : Profile
    {
        public DetailedBook()
        {
            CreateMap<Data.Models.Book, DataTransferObjects.Response.DetailedBook>()
                .ForMember(destination => destination.Publisher,
                    map => map.MapFrom(
                        (source, destination) => source.Publisher.Name));
        }
    }
}