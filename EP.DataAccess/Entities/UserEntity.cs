

namespace EP.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
    }
}
