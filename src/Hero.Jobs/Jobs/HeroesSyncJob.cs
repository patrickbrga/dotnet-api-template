using Core.Queries.Heroes;
using MediatR;
using Quartz;
using Serilog;

namespace Jobs.Jobs
{
    public class HeroesSyncJob : IJob
    {
        public static readonly JobKey JobKey = new JobKey("HeroesSyncJobKey", "Heroes");
        public static readonly TriggerKey TriggerKey = new TriggerKey("HeroesSyncJobTrigger", "Heroes");

        private readonly IMediator mediator;

        public HeroesSyncJob(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("<{EventoId}> - Iniciando Execução", "HeroJob");
            await mediator.Send(new GetHeroQuery());
        }
    }
}