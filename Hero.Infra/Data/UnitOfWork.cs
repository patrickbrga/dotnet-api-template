using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateExecutionStrategy()
        {
            _appDbContext.Database.CreateExecutionStrategy();
        }

        public IDbContextTransaction OpenTransaction()
        {
            return _appDbContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _appDbContext.Database.RollbackTransaction();
        }

        public async Task<bool> Commit()
        {
            var save = await _appDbContext.SaveChangesAsync();
            _appDbContext.Database.CommitTransaction();

            return save > 0;
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}