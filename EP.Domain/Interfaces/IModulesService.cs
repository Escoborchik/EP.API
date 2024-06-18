using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IModulesService
    {
        Task<Guid> CreateModule(Module module);
        Task DeleteModule(Guid guid);
        Task<List<Module>> GetAllModules();
        Task UpdateModule(Module module);     
    }
}