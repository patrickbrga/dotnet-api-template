using Core.Commands.Heroes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("heroes")]
    public class HeroController : Controller
    {
        private readonly IMediator mediator;
        public HeroController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHeroCommand request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}