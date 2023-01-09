using MediatR;
using Quartz;
using Serilog;

namespace Jobs.Jobs
{
    public class HeroesSyncJob : IJob
    {
        public static JobKey JobKey = new JobKey("HeroesSyncJobKey", "Heroes");
        public static TriggerKey TriggerKey = new TriggerKey("HeroesSyncJobTrigger", "Heroes");

        private IMediator mediator;

        public HeroesSyncJob(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("<{EventoId}> - Iniciando Execução", "HeroJob");
        }
    }
}