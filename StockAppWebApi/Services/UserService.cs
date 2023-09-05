using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User user)
        {
            var existingUserByUsername = _userRepository.GetByUsername(user.Username);
            if (existingUserByUsername != null)
            {
                throw new ArgumentException("Username already exists");
            }
            var existingUserByEmail = _userRepository.GetByEmail(user.Email);
            if (existingUserByEmail != null)
            {
                throw new ArgumentException("Email already exists");
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.HashedPassword);
            user.HashedPassword = hashPassword;
            throw new NotImplementedException();
        }
    }
}
