using Core.Entities.Heroes;
using Core.Interfaces.Repositories.Heroes;

namespace Infra.Data.Repositories.Heroes
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        private readonly AppDbContext dbContext;

        public HeroRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
