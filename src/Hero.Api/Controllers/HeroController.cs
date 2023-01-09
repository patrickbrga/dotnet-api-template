using Core.Commands.Heroes;
using Core.Queries.Heroes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Api;

namespace Api.Controllers
{
    [ApiController]
    [BaseRoute("heroes")]
    public class HeroController : Controller
    {
        private readonly IMediator mediator;
        public HeroController(IMediator mediator)
            => this.mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] GetHeroQuery request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHeroCommand request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}