using disprz.Model;

namespace disprz.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user);
    }
}
