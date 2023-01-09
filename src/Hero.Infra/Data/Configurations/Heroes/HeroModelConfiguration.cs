using Core.Entities.Heroes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations.Heroes
{
    public class HeroModelConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("heroes");

            entityTypeBuilder.Property(e => e.Nome)
                .IsRequired()
                .IsUnicode(true);
        }
    }
}