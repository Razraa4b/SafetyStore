using SafetyStore.Domain.Contracts;
using SafetyStore.Domain.Entities;

namespace SafetyStore.Infrastructure.Persistance.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByName(string name);
        Task<User?> GetByEmail(string email);
    }
}
