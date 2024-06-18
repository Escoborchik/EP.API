using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}