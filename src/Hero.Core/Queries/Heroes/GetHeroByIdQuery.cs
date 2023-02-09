using Core.Models.Responses;
using MediatR;
using Shared.Core;

namespace Core.Queries.Heroes
{
    public class GetHeroByIdQuery : IRequest<Result<HeroResponse>>
    {
        public Guid Id { get; set; }

        public GetHeroByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
