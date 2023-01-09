using Jobs.Jobs;
using Quartz;

namespace Jobs
{
    public class SchedulerJobs
    {
        private readonly IScheduler scheduler;

        public SchedulerJobs(IScheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        public async Task<IScheduler> CreateScheduler()
        {
            // define the job and tie it to our HelloJob class
            var job = JobBuilder.Create<HeroesSyncJob>().WithIdentity(HeroesSyncJob.JobKey).Build();

            // Trigger the job to run now, and then every 40 seconds
            var trigger = TriggerBuilder.Create()
                .WithIdentity(HeroesSyncJob.TriggerKey)
                .WithCronSchedule("0 0/1 * 1/1 * ? *")
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            scheduler.Start();

            return scheduler;
        }
    }
}
