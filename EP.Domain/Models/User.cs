using System;

namespace EP.Domain.Models
{
    public class User
    {
        private User(Guid id, string email, string passwordHash)
        {
            Id = id;
            Email = email;
            HashPassword = passwordHash;
        }

        public Guid Id { get; set; }       
        public string Email { get; set; }
        public string HashPassword { get; set; }

        public static User Create(Guid id, string email, string passwordHash)
        {
            

            return new User(id, email, passwordHash);
        }
    }
}
