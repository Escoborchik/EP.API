using EP.DataAccess.Entities;
using EP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using EP.Domain.Interfaces;


namespace EP.DataAccess.Repositories
{
    public class ModulesRepository : IModulesRepository
    {
        private readonly EPDbContext _context;
        public ModulesRepository(EPDbContext context)
        {
            _context = context;
        }

        public async Task<List<Module>> Get()
        {
            var moduleEntities = await _context.Modules.ToListAsync();


            return moduleEntities
                .Select(m => Module.Create(m.Uuid, m.Title, m.Type).Item1)
                .ToList();
        }       
        public async Task<Guid> Create(Module module)
        {
            var moduleEntity = new ModuleEntity()
            {
                Uuid = module.Uuid,
                Title = module.Title,
                Type = module.Type,
            };

            await _context.Modules.AddAsync(moduleEntity);
            await _context.SaveChangesAsync();

            return moduleEntity.Uuid;
        }

        public async Task Update(Module module)
        {
            var moduleEntity = await _context.Modules.FirstOrDefaultAsync(m => m.Uuid == module.Uuid)
                ?? throw new Exception("Такого модуля нет!");

            moduleEntity.Title = module.Title;
            moduleEntity.Type = module.Type;             

            _context.Modules.Update(moduleEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid uuid)
        {
            var moduleEntity = _context.Modules.FirstOrDefault(m => m.Uuid == uuid)
                ?? throw new Exception("Такого модуля нет!");

            _context.Modules.Remove(moduleEntity);

            await _context.SaveChangesAsync();
        }
       
    }
}
