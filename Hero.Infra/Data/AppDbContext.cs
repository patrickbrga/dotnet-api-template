using Core.Entities.Heroes;
using Infra.Data.Configurations.Heroes;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hero> Hero { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.EnableSensitiveDataLogging();
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            modelBuilder.ApplyConfiguration(new HeroModelConfiguration());

            // Definindo todas as datas para o sem TimeZone
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                 .SelectMany(t => t.GetProperties())
                 .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
            {
                property.SetColumnType("timestamp without time zone");
            }
        }

        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
        }
    }
}