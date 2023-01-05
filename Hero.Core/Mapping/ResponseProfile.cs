using AutoMapper;
using Core.Entities.Heroes;
using Core.Models.Responses;

namespace Core.Mapping
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Hero, HeroResponse>();
        }
    }
}