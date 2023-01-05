using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void CreateExecutionStrategy();

        IDbContextTransaction OpenTransaction();

        void RollbackTransaction();

        Task<bool> Commit();
    }
}
