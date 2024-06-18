
using EP.Domain.Interfaces;
using EP.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace EP.DataAccess.Repositories
{
    public class HeadsRepository : IHeadsRepository
    {
        private readonly EPDbContext _context;
        public HeadsRepository(EPDbContext context)
        {
            _context = context;
        }
        public async Task<List<Head>> Get()
        {
            return await _context.Heads.Select(h => Head.Create(h.Uuid, h.FullName)).ToListAsync();
        }

        public async Task<Head> GetHead(Guid uuid)
        {
            return await _context.Heads.Where(h => h.Uuid == uuid).Select(h => Head.Create(h.Uuid, h.FullName)).FirstOrDefaultAsync();
        }
    }
}
