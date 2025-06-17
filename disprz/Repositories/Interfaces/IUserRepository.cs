using disprz.Model;

namespace disprz.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user);
    }
}
