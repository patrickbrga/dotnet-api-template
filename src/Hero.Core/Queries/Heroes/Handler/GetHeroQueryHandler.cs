using AutoMapper;
using Core.Interfaces.Repositories.Heroes;
using Core.Models.Responses;
using MediatR;
using Shared.Core;

namespace Core.Queries.Heroes.Handler
{
    public class GetHeroQueryHandler : IRequestHandler<GetHeroQuery, Result<IEnumerable<HeroResponse>>>
    {
        private readonly IHeroRepository heroRepository;
        private readonly IMapper mapper;

        public GetHeroQueryHandler(IHeroRepository heroRepository, IMapper mapper)
        {
            this.heroRepository = heroRepository;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<HeroResponse>>> Handle(GetHeroQuery query, CancellationToken cancellationToken)
        {
            var result = new Result<IEnumerable<HeroResponse>>();

            var heroes = await heroRepository.Get(query.Nome, query.Take, query.Skip, query.SortingProp, query.Ascending);

            result.Value = mapper.Map<IEnumerable<HeroResponse>>(heroes.Result(out var count));
            result.Count = count;

            return result;
        }
    }
}
