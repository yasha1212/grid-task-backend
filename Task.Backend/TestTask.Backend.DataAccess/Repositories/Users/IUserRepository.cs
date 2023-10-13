using TestTask.Backend.DataAccess.Entities;

namespace TestTask.Backend.DataAccess.Repositories.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(int id);
        Task UpdateAsync(User user);
    }
}

