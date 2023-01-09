using Core.Entities.Heroes;
using Shared.Infra;

namespace Core.Interfaces.Repositories.Heroes
{
    public interface IHeroRepository : IBaseRepository<Hero>
    {
        Task<AsyncOutResult<IEnumerable<Hero>, int>> Get(string nome, int? take, int? offSet, string sortingProp, bool? asc);
    }
}
