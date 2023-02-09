using AutoMapper;
using Core.Entities.Heroes;
using Core.Interfaces;
using Core.Interfaces.Repositories.Heroes;
using Core.Models.Responses;
using MediatR;
using Serilog;
using Shared.Core;

namespace Core.Commands.Heroes.Handler
{
    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, Result<HeroResponse>>
    {
        private readonly IHeroRepository heroRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateHeroCommandHandler(IHeroRepository heroRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.heroRepository = heroRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<HeroResponse>> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<HeroResponse>();

            var hero = mapper.Map<Hero>(request);

            try
            {
                unitOfWork.OpenTransaction();

                await heroRepository.AddAsync(hero);

                await unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "<{EventoId}> - Falha ao cadastrar heroi", "ErroCadastrarHeroi");
                unitOfWork.RollbackTransaction();
            }

            result.Value = mapper.Map<HeroResponse>(hero);

            return result;
        }
    }
}
