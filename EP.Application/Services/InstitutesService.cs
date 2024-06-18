using EP.Domain.Interfaces;
using EP.Domain.Models;

namespace EP.Application.Services
{
    public class InstitutesService : IInstitutesService
    {
        private readonly IInstitutesRepository _instituteRepository;

        public InstitutesService(IInstitutesRepository instituteRepository)
        {
            _instituteRepository = instituteRepository;
        }

        public async Task<List<Institute>> GetAllInstitutes()
        {
            return await _instituteRepository.Get();
        }

        public async Task<(Institute, string)> GetInstitute(Guid uuid)
        {
            string error = string.Empty;
            var result = await _instituteRepository.GetInstitute(uuid);
            if (result == null)
            {
                error = "Такого института нет!";
            }
            return (result, error);            
        }
    }
}
