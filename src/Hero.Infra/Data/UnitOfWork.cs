using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public void CreateExecutionStrategy() => _appDbContext.Database.CreateExecutionStrategy();

        public IDbContextTransaction OpenTransaction() => _appDbContext.Database.BeginTransaction();

        public void RollbackTransaction() => _appDbContext.Database.RollbackTransaction();

        public async Task CommitTransactionAsync()
        {
            await _appDbContext.SaveChangesAsync();
            await _appDbContext.Database.CommitTransactionAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}