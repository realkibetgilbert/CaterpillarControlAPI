using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace CaterpillarControlService.API.Infrastructure.SqlServerImplementations
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly CaterpillarDbContext _context;

        public PlanetRepository(CaterpillarDbContext context)
        {
            _context = context;
        }

        public async Task<Planet> GetPlanetById(long id)
        {
            return await _context.Planets.FirstOrDefaultAsync(p => p.Id == id);   
        }

        public async Task<List<Planet>> GetPlanets()
        {
            return await _context.Planets.ToListAsync();
        }
    }
}
