using EP.DataAccess.Entities;
using EP.Domain.Interfaces;
using EP.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EP.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EPDbContext _context;
        public UserRepository(EPDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                HashPassword = user.HashPassword,
            };

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email)
                ?? throw new Exception("Такого пользователя нет!");

            return User.Create(userEntity.Id, userEntity.Email, userEntity.HashPassword);
        }
    }
}
