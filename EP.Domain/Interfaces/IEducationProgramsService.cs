using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IEducationProgramsService
    {
        Task<Guid> CreateEducationProgram(EducationProgram educationProgram);
        Task DeleteEducationProgram(Guid guid);
        Task<List<EducationProgram>> GetAllEducationPrograms();
        Task UpdateEducationProgram(EducationProgram educationProgram);
        Task AddModules(Guid uuidProgram,List<Guid> uuidModules);
        Task<List<Module>> GetModules(Guid uuidProgram);
    }
}