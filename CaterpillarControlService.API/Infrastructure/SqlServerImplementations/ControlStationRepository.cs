using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CaterpillarControlService.API.Infrastructure.SqlServerImplementations
{
    public class ControlStationRepository : IControlStationRepository
    {
        private readonly CaterpillarDbContext _context;

        public ControlStationRepository(CaterpillarDbContext context)
        {
            _context = context;
        }
        public async Task<ControlStation> CreateControlStationAsync(ControlStation tollStation)
        {
            await _context.ControlStations.AddAsync(tollStation);

            await _context.SaveChangesAsync();

            return tollStation;
        }

        public async Task<ControlStation> DeleteAsync(long id)
        {
            var existingControlStation = await _context.ControlStations.FirstOrDefaultAsync(r => r.Id == id);

            if (existingControlStation == null) { return null; }

            _context.ControlStations.Remove(existingControlStation);

            await _context.SaveChangesAsync();

            return existingControlStation;
        }

        public async Task<List<ControlStation>> GetAllAsync()
        {
            var controlStations = await _context.ControlStations.ToListAsync();

            return controlStations;
        }

        public  async Task<ControlStation> GetByIdAsync(long id)
        {

            return await _context.ControlStations.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ControlStation> UpdateAsync(long id, ControlStation tollStation)
        {
            var existingControlStation = await _context.ControlStations.FirstOrDefaultAsync(r => r.Id == id);

            if (existingControlStation == null)
            {
                return null;
            }

            existingControlStation.Name = tollStation.Name;

            await _context.SaveChangesAsync();

            return existingControlStation;
        }
    }
}
