using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class DetailedAuthor : Profile
    {
        public DetailedAuthor()
        {
            CreateMap<Data.Models.Author, DataTransferObjects.Response.DetailedAuthor>();
        }
    }
}