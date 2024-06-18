using EP.Domain.Interfaces;
using EP.Domain.Models;

namespace EP.Application.Services
{
    public class EducationProgramsService : IEducationProgramsService
    {
        private readonly IEducationProgramsRepository _programRepository;

        public EducationProgramsService(IEducationProgramsRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<List<EducationProgram>> GetAllEducationPrograms()
        {
            return await _programRepository.Get();
        }

        public async Task<Guid> CreateEducationProgram(EducationProgram educationProgram)
        {
            return await _programRepository.Create(educationProgram);
        }

        public async Task UpdateEducationProgram(EducationProgram educationProgram)
        {
            await _programRepository.Update(educationProgram);
        }

        public async Task DeleteEducationProgram(Guid guid)
        {
            await _programRepository.Delete(guid);
        }

        public async Task<List<Module>> GetModules(Guid uuidProgram)
        {
            return await _programRepository.GetModules(uuidProgram);
        }

        public async Task AddModules(Guid uuidProgram, List<Guid> uuidModules)
        {
            await _programRepository.AddModules(uuidProgram, uuidModules);
        }

        
    }
}
