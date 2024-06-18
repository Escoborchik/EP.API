using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IEducationProgramsRepository
    {
        Task<Guid> Create(EducationProgram program);
        Task Delete(Guid uuid);        
        Task<List<EducationProgram>> Get();
        Task Update(EducationProgram program);
        Task AddModules(Guid uuidProgram, List<Guid> uuidModules);
        Task<List<Module>> GetModules(Guid uuidProgram);
    }
}