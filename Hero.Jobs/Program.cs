using CrystalQuartz.AspNetCore;
using IoC;
using Jobs.Jobs;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Quartz;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

DependencyRegistration.Register(Assembly.GetExecutingAssembly(), builder.Configuration, builder.Host, builder.Services);

builder.Services.Configure<KestrelServerOptions>(o => o.AllowSynchronousIO = true);
builder.Services.AddQuartz(q => q.UseMicrosoftDependencyInjectionJobFactory());
builder.Services.AddQuartzHostedService(opt => opt.WaitForJobsToComplete = true);

var app = builder.Build();

IScheduler scheduler = await app.Services.GetService<ISchedulerFactory>().GetScheduler();

// define the job and tie it to our HelloJob class
var job = JobBuilder.Create<HeroesSyncJob>().WithIdentity(HeroesSyncJob.JobKey).Build();

// Trigger the job to run now, and then every 40 seconds
var trigger = TriggerBuilder.Create()
    .WithIdentity(HeroesSyncJob.TriggerKey)
    .WithCronSchedule("0 0/1 * 1/1 * ? *")
    .Build();

await scheduler.ScheduleJob(job, trigger);

app.Map(string.Empty, app =>
{
    app.UseCrystalQuartz(() => scheduler);
});

app.Run();
