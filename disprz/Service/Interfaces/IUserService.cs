using disprz.Model;

namespace disprz.Service.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(User user, string plainPassword);
        Task<string?> AuthenticateAsync(string email, string password);
    }
}
