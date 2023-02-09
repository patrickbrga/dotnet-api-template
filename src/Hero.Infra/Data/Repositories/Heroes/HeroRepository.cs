using Core.Entities.Heroes;
using Core.Interfaces.Repositories.Heroes;
using Microsoft.EntityFrameworkCore;
using Shared.Infra;

namespace Infra.Data.Repositories.Heroes
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        private readonly AppDbContext dbContext;

        public HeroRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AsyncOutResult<IEnumerable<Hero>, int>> Get(string nome, int? take, int? offSet, string sortingProp, bool? asc)
        {
            var query = dbContext.Hero
                .Where(e => !e.Deletado)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(e => e.Nome.ToLower().StartsWith(nome.ToLower()));

            if (!string.IsNullOrEmpty(sortingProp) && asc != null
                && DataHelpers.CheckExistingProperty<Hero>(sortingProp))
                query = query.OrderByDynamic(sortingProp, (bool)asc);

            if (take != null && offSet != null)
                return new AsyncOutResult<IEnumerable<Hero>, int>(await query.Skip((int)offSet).Take((int)take).ToListAsync(), await query.CountAsync());

            return new AsyncOutResult<IEnumerable<Hero>, int>(await query.ToListAsync(), await query.CountAsync());
        }
    }
}
