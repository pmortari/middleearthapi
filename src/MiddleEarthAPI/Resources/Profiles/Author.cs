using AutoMapper;

namespace MiddleEarthAPI.Resources.Profiles
{
    public class Author : Profile
    {
        public Author()
        {
            CreateMap<Data.Models.Author, DataTransferObjects.Response.Author>();
        }
    }
}