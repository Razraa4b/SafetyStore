using Microsoft.EntityFrameworkCore.Storage;
using SafetyStore.Domain.Contracts;
using SafetyStore.Domain.Entities;
using SafetyStore.Infrastructure.Persistance.Repositories;

namespace SafetyStore.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext _dbContext;
        private readonly IDbContextTransaction _transaction;

        public IRepository<User> UserRepository { get; init; }

        public UnitOfWork(MainDbContext dbContext)
        {
            _dbContext = dbContext;

            UserRepository = new UserRepository(dbContext);

            _transaction = _dbContext.Database.BeginTransaction();
        }

        public async Task Commit(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task Rollback(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _dbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _transaction.DisposeAsync();
            await _dbContext.DisposeAsync();
        }
    }
}
