using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.Quartz;
using Core.Sercurity;
using Infra.Data;
using IoC.Extensions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;

namespace IoC
{
    public static class DependencyRegistration
    {
        public static void Register(Assembly assembly, IConfiguration configuration, IHostBuilder host, IServiceCollection services)
        {
            var defaultConnection = Environment.GetEnvironmentVariable("DefaultConnection");

            if (string.IsNullOrEmpty(defaultConnection))
                defaultConnection = configuration.GetConnectionString("DefaultConnection");

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            host.UseSerilog();

            services.AddMediatR(assembly);
            services.AddMapping();

            services.AddEntityConfiguration(defaultConnection);

            BuildDependencyInjectionProvider(assembly, host);
        }

        private static void BuildDependencyInjectionProvider(Assembly assembly, IHostBuilder host)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(AuthenticatedUser));
            var infraAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            host.ConfigureContainer<ContainerBuilder>((_, builder) =>
            {
                if (assembly.GetName().Name == "Jobs")
                {
                    builder.RegisterModule(new QuartzAutofacFactoryModule());
                    builder.RegisterModule(new QuartzAutofacJobsModule(assembly));
                }

                builder.RegisterAssemblyTypes(assembly, coreAssembly, infraAssembly).AsImplementedInterfaces();
            });
        }
    }
}