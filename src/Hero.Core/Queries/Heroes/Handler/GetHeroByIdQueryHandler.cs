using AutoMapper;
using Core.Interfaces.Repositories.Heroes;
using Core.Models.Responses;
using MediatR;
using Shared.Core;

namespace Core.Queries.Heroes.Handler
{
    public class GetHeroByIdQueryHandler : IRequestHandler<GetHeroByIdQuery, Result<HeroResponse>>
    {
        private readonly IHeroRepository heroRepository;
        private readonly IMapper mapper;

        public GetHeroByIdQueryHandler(IHeroRepository heroRepository, IMapper mapper)
        {
            this.heroRepository = heroRepository;
            this.mapper = mapper;
        }

        public async Task<Result<HeroResponse>> Handle(GetHeroByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new Result<HeroResponse>();

            var hero = await heroRepository.GetById(request.Id);

            if (hero == null)
            {
                result.WithError("Heroi não encontrado");
                return result;
            }

            result.Value = mapper.Map<HeroResponse>(hero);

            return result;
        }
    }
}
