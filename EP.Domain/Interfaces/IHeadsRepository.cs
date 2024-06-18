using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IHeadsRepository
    {
        Task<List<Head>> Get();
        Task<Head> GetHead(Guid uuid);
    }
}