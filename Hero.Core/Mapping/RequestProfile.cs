using AutoMapper;
using Core.Commands.Heroes;
using Core.Entities.Heroes;

namespace Core.Mapping
{
    public class ResquestProfile : Profile
    {
        public ResquestProfile()
        {
            CreateMap<CreateHeroCommand, Hero>();
        }
    }
}