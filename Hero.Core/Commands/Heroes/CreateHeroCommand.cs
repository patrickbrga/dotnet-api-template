using Core.Models.Responses;
using MediatR;
using Shared.Core;

namespace Core.Commands.Heroes
{
    public class CreateHeroCommand : IRequest<Result<HeroResponse>>
    {
        public string Nome { get; set; }
    }
}
