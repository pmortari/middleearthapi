using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class DetailedPublisher : Profile
    {
        public DetailedPublisher()
        {
            CreateMap<Data.Models.Publisher, DataTransferObjects.Response.DetailedPublisher>();
        }
    }
}
