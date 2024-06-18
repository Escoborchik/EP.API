using EP.Domain.Interfaces;
using EP.Domain.Models;

namespace EP.Application.Services
{
    public class ModulesService : IModulesService
    {
        private readonly IModulesRepository _moduleRepository;

        public ModulesService(IModulesRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<List<Module>> GetAllModules()
        {
            return await _moduleRepository.Get();
        }

        public async Task<Guid> CreateModule(Module module)
        {
            return await _moduleRepository.Create(module);
        }

        public async Task UpdateModule(Module module)
        {
            await _moduleRepository.Update(module);
        }

        public async Task DeleteModule(Guid guid)
        {
            await _moduleRepository.Delete(guid);
        }
        
    }
}
