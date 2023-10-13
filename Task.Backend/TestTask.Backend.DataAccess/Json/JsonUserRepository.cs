using System.Text.Json;
using TestTask.Backend.DataAccess.Entities;
using TestTask.Backend.DataAccess.Repositories.Users;

namespace TestTask.Backend.DataAccess.Json
{
    internal class JsonUserRepository : IUserRepository
    {
        private const string FILE_PATH = "./users.json";

        public JsonUserRepository()
        {
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await ReadJsonFileAsync();
        }

        public async Task AddAsync(User user)
        {
            var users = await ReadJsonFileAsync();

            var newId = users.OrderByDescending(u => u.Id)
                .Select(u => u.Id)
                .First() + 1;

            user.Id = newId;

            users.Add(user);

            await RewriteJsonFileAsync(users);
        }

        public async Task DeleteAsync(int id)
        {
            var users = await ReadJsonFileAsync();
            var userToRemove = users.First(u => u.Id == id);

            users.Remove(userToRemove);

            await RewriteJsonFileAsync(users);
        }

        public async Task UpdateAsync(User user)
        {
            var users = await ReadJsonFileAsync();
            var userToUpdate = users.First(u => u.Id == user.Id);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;

            await RewriteJsonFileAsync(users);
        }

        private async Task<ICollection<User>> ReadJsonFileAsync()
        {
            using var stream = File.OpenRead(FILE_PATH);
            return await JsonSerializer.DeserializeAsync<ICollection<User>>(stream);
        }

        private async Task RewriteJsonFileAsync(ICollection<User> users)
        {
            using var stream = File.Create(FILE_PATH);
            await JsonSerializer.SerializeAsync(stream, users);
        }
    }
}

