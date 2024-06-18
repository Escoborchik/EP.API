using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IUserService
    {
        Task Register(string email, string password);
        Task<string> Login(string email, string password);
    }
}