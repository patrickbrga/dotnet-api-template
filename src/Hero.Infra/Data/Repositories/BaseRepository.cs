using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Infra;

namespace Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<AsyncOutResult<IEnumerable<TEntity>, int>> GetAll(int? take, int? offSet, string sortingProp, bool? asc)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(sortingProp) && asc != null)
                if (DataHelpers.CheckExistingProperty<TEntity>(sortingProp))
                    query = query.OrderByDynamic(sortingProp, (bool)asc);

            if (take != null && offSet != null)
                return new AsyncOutResult<IEnumerable<TEntity>, int>(await query.Skip((int)offSet).Take((int)take).ToListAsync(), await query.CountAsync());

            return new AsyncOutResult<IEnumerable<TEntity>, int>(await query.ToListAsync(), await query.CountAsync());
        }

        public virtual async Task<IEnumerable<TEntity>> Get(int? take, int? offSet, string sortingProp, bool? asc)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(sortingProp) && asc != null)
                if (DataHelpers.CheckExistingProperty<TEntity>(sortingProp))
                    query = query.OrderByDynamic(sortingProp, (bool)asc);

            if (take != null && offSet != null)
                return await query.Skip((int)offSet).Take((int)take).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entity);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                dbContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> listEntity)
        {
            try
            {
                dbContext.Set<TEntity>().RemoveRange(listEntity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                dbContext.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "<{EventoId}> - Falha salvar entidade no banco.", "ErroAtualizarEntidadeBanco");
                return false;
            }
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<TEntity> listEntity)
        {
            try
            {
                dbContext.UpdateRange(listEntity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
