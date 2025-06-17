using Dapper;
using disprz.Data;
using disprz.Model;
using disprz.Repositories.Interfaces;

namespace disprz.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionFactory _factory;

        public UserRepository(DbConnectionFactory factory) => _factory = factory;

        public async Task<User?> GetByEmailAsync(string email)
        {
            var sql = $"SELECT * FROM users WHERE email = @Email";
            using var db = _factory.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
        }

        public async Task CreateAsync(User user)
        {
            var properties = typeof(User).GetProperties().Where(p => p.Name.ToLower() != "id");
            var columnNames = string.Join(", ", properties.Select(p => p.Name.ToLower()));
            var paramNames = string.Join(", ", properties.Select(p => "@" + p.Name));
            var sql = $"INSERT INTO users ({columnNames}) VALUES ({paramNames})";
            using var db = _factory.CreateConnection();
            await db.ExecuteAsync(sql, user);
        }
    }
}
