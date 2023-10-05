using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace CaterpillarControlService.API.Infrastructure.SqlServerImplementations
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly CaterpillarDbContext _context;

        public ShiftRepository(CaterpillarDbContext context)
        {
            _context = context;
        }
        public async Task<List<Shift>> GetAllShiftsAsync()
        {
            return await _context.Shifts.ToListAsync();
        }
    }
}
