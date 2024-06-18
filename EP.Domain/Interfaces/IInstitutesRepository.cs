using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IInstitutesRepository
    {
        Task<List<Institute>> Get();
        Task<Institute> GetInstitute(Guid uuid);
    }
}