using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IHeadsService
    {
        Task<List<Head>> GetAllHeads();
        Task<(Head, string)> GetHead(Guid uuid);
    }
}