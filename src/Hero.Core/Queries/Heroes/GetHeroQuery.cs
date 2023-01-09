using Core.Models.Responses;
using MediatR;
using Shared.Core;
using Shared.Core.Models;

namespace Core.Queries.Heroes
{
    public class GetHeroQuery : BaseRequestFilter, IRequest<Result<IEnumerable<HeroResponse>>>
    {
        public string? Nome { get; set; }
    }
}
