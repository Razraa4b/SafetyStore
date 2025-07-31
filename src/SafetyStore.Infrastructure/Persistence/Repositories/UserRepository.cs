using Microsoft.EntityFrameworkCore;
using SafetyStore.Domain.Entities;

namespace SafetyStore.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _dbContext;

        public UserRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
        }

        public Task Update(User entity)
        {
            _dbContext.Users.Update(entity);
            return Task.CompletedTask;
        }

        public Task Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users.AsQueryable();
        }

        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByName(string name)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
