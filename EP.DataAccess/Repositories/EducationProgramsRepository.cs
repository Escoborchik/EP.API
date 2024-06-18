using EP.DataAccess.Entities;
using EP.Domain.Interfaces;
using EP.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace EP.DataAccess.Repositories
{
    public class EducationProgramsRepository : IEducationProgramsRepository
    {
        private readonly EPDbContext _context;
        public EducationProgramsRepository(EPDbContext context)
        {
            _context = context;
        }

        public async Task<List<EducationProgram>> Get()
        {
            var programEntities = await _context.EducationPrograms.Include(p => p.Institute)
                .Include(p => p.Head).Include(p => p.Modules)
                .ToListAsync();


            return programEntities.Select(p => EducationProgram.Create(p.Uuid, p.Title, p.Status, p.Cypher, p.Level,
                p.Standard,
                Institute.Create(p.Institute.Uuid, p.Institute.Title),
                Head.Create(p.Head.Uuid, p.Head.FullName),
                p.AccreditationTime,
                p.Modules.Select(m => Module.Create(m.Uuid, m.Title, m.Type).Item1).ToList()).Item1).ToList();
        }       
        public async Task<Guid> Create(EducationProgram program)
        {
            var programEntity = new EducationProgramEntity()
            {
                Uuid = program.Uuid,
                Title = program.Title,
                Status = program.Status,
                Cypher = program.Cypher,
                Level = program.Level,
                Standard = program.Standard,
                Institute = _context.Institutes.FirstOrDefault(i => i.Uuid == program.Institute.Uuid),
                Head = _context.Heads.FirstOrDefault(i => i.Uuid == program.Head.Uuid),
                AccreditationTime = program.AccreditationTime                
            };

            await _context.EducationPrograms.AddAsync(programEntity);
            await _context.SaveChangesAsync();

            return programEntity.Uuid;
        }

        public async Task Update(EducationProgram program)
        {
            var programEntity = await _context.EducationPrograms.FirstOrDefaultAsync(p => p.Uuid == program.Uuid)
                ?? throw new Exception("Такой образовательной программы нет!");
            programEntity.Title = program.Title;
            programEntity.Status = program.Status;
            programEntity.Cypher = program.Cypher;
            programEntity.Level = program.Level;
            programEntity.Standard = program.Standard;
            programEntity.Institute = _context.Institutes.FirstOrDefault(i => i.Uuid == program.Institute.Uuid);
            programEntity.Head = _context.Heads.FirstOrDefault(i => i.Uuid == program.Head.Uuid);            
            programEntity.AccreditationTime = program.AccreditationTime;
            _context.EducationPrograms.Update(programEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid uuid)
        {
            var programEntity = _context.EducationPrograms.FirstOrDefault(p => p.Uuid == uuid) 
                ?? throw new Exception("Такой образовательной программы нет!");

            _context.EducationPrograms.Remove(programEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Module>> GetModules(Guid uuidProgram)
        {
            var programEntity = await _context.EducationPrograms.Where(m => m.Uuid == uuidProgram).Include(p => p.Modules).FirstOrDefaultAsync()
                ?? throw new Exception("Такой образовательной программы нет!");
            
            return programEntity.Modules.Select(m => Module.Create(m.Uuid,m.Title,m.Type).Item1).ToList();
        }
        public async Task AddModules(Guid uuidProgram, List<Guid> uuidModules)
        {
            var programEntity = _context.EducationPrograms.Include(p => p.Modules).FirstOrDefault(m => m.Uuid == uuidProgram) 
                ?? throw new Exception("Такой образовательной программы нет!");

            
            programEntity.Modules = _context.Modules.Where(m => uuidModules.Contains(m.Uuid)).ToList();
            _context.EducationPrograms.Update(programEntity);
            await _context.SaveChangesAsync();
        }

        
    }
}
