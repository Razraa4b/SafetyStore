using SafetyStore.Domain.Entities;

namespace SafetyStore.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IRepository<User> UserRepository { get; }

        Task Commit(CancellationToken cancellationToken);
        Task Rollback(CancellationToken cancellationToken);
    }
}
