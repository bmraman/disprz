using disprz.Helpers;
using disprz.Model;
using disprz.Repositories.Interfaces;
using disprz.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace disprz.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public UserService(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task RegisterAsync(User user, string plainPassword)
        {
            var hasher = new PasswordHasher<object>();
            user.PasswordHash = hasher.HashPassword(null, plainPassword);
            user.Created = DateTime.UtcNow;
            await _repo.CreateAsync(user);
        }

        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var user = await _repo.GetByEmailAsync(email);
            if (user == null) return null;

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.PasswordHash, password);
            if (result != PasswordVerificationResult.Success) return null;

            return JwtTokenHelper.GenerateToken(user, _config);
        }
    }
}
