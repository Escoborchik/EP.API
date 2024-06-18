using EP.Domain.Models;

namespace EP.Domain.Interfaces
{
    public interface IModulesRepository
    {
        Task<Guid> Create(Module module);
        Task Delete(Guid uuid);
        Task<List<Module>> Get();        
        Task Update(Module module);        
    }
}