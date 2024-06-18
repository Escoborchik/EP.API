using EP.Domain.Models;
using EP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EP.DataAccess.Repositories
{
    public class InstitutesRepository : IInstitutesRepository
    {
        private readonly EPDbContext _context;
        public InstitutesRepository(EPDbContext context)
        {
            _context = context;
        }
        public async Task<List<Institute>> Get()
        {
            return await _context.Institutes.Select(i => Institute.Create(i.Uuid, i.Title)).ToListAsync();
        }

        public async Task<Institute> GetInstitute(Guid uuid)
        {             

            return await _context.Institutes.Where(i => i.Uuid == uuid)
                .Select(i => Institute.Create(i.Uuid, i.Title))
                .FirstOrDefaultAsync();
        }
    }
}
