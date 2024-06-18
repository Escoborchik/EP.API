using EP.Domain.Interfaces;
using EP.Domain.Models;
using System.Runtime.CompilerServices;

namespace EP.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository,
            IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = User.Create(Guid.NewGuid(), email, hashedPassword);
            await _userRepository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            try
            {
                var user = await _userRepository.GetByEmail(email);

                var result = _passwordHasher.Verify(password, user.HashPassword);

                if (result == false)
                {
                    throw new Exception("Неверный пароль!");
                }

                var token = _jwtProvider.GenerateToken(user);

                return token;
            }
            catch
            {
                throw;
            }                                   
        }
    }
}
