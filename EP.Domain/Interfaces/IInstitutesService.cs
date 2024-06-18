using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IInstitutesService
    {
        Task<List<Institute>> GetAllInstitutes();

        Task<(Institute, string)> GetInstitute(Guid uuid);
    }
}