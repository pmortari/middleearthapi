using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class Publisher : Profile
    {
        public Publisher()
        {
            CreateMap<Data.Models.Publisher, DataTransferObjects.Response.Publisher>();
        }
    }
}
