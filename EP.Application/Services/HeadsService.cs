using EP.Domain.Interfaces;
using EP.Domain.Models;

namespace EP.Application.Services
{
    public class HeadsService : IHeadsService
    {
        private readonly IHeadsRepository _headRepository;

        public HeadsService(IHeadsRepository headRepository)
        {
            _headRepository = headRepository;
        }

        public async Task<List<Head>> GetAllHeads()
        {
            return await _headRepository.Get();
        }

        public async Task<(Head, string)> GetHead(Guid uuid)
        {
            string error = string.Empty;
            var result = await _headRepository.GetHead(uuid);
            if (result == null)
            {
                error = "Такого ответсвенного лица нет!";
            }
            return (result, error);
        }
    }
}
