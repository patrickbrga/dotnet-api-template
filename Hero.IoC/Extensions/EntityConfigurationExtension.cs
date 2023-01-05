using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace IoC.Extensions
{
    public static class EntityConfigurationExtension
    {
        public static IServiceCollection AddEntityConfiguration(this IServiceCollection services, string defaultConnection)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
                options
                    .UseNpgsql(defaultConnection, options =>
                        options.MigrationsHistoryTable("__efmigrationshistory", "public"))
                    .ReplaceService<ISqlGenerationHelper, CustomNameSqlGenerationHelper>()
            );

            return services;
        }

        public class CustomNameSqlGenerationHelper : RelationalSqlGenerationHelper
        {
            public CustomNameSqlGenerationHelper(RelationalSqlGenerationHelperDependencies dependencies)
                : base(dependencies) { }

            private static string Customize(string input) => input.ToLower();
            public override string DelimitIdentifier(string identifier) => base.DelimitIdentifier(Customize(identifier));
            public override void DelimitIdentifier(StringBuilder builder, string identifier) => base.DelimitIdentifier(builder, Customize(identifier));
        }
    }
}
