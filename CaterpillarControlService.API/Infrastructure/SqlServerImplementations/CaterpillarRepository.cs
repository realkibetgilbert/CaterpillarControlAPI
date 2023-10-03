using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Dtos.Caterpillar;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using static CaterpillarControlService.API.Core.Utils.Enums.Enumeration;

namespace CaterpillarControlService.API.Infrastructure.SqlServerImplementations
{
    public class CaterpillarRepository : ICaterpillarRepository
    {
        private readonly CaterpillarDbContext _context;

        public CaterpillarRepository(CaterpillarDbContext context)
        {
            _context = context;
        }
        public async Task<Caterpillar> Add(Caterpillar caterpillar)
        {
            await _context.Caterpillars.AddAsync(caterpillar);

            await _context.SaveChangesAsync();

            return caterpillar;
        }

        public async Task<Caterpillar> GetCaterpillar(long id)
        {
            return await _context.Caterpillars.FirstOrDefaultAsync(x => x.Id == id);

        }

        public bool IsCrossingBoundary(Caterpillar caterpillar, CaterpillarMovementDto movementDto, Planet planet)
        {
            int newX = caterpillar.X;

            int newY = caterpillar.Y;

            
            switch (movementDto.Direction)
            {
                case DirectionType.Up:
                    newY -= movementDto.Distance;
                    break;
                case DirectionType.Down:
                    newY += movementDto.Distance;
                    break;
                case DirectionType.Left:
                    newX -= movementDto.Distance;
                    break;
                case DirectionType.Right:
                    newX += movementDto.Distance;
                    break;
                default:
                    return false; 
            }

            
            if (newX < 0 || newX >= planet.Width || newY < 0 || newY >= planet.Height)
            {
                return true; 
            }

            return false; 
        }


        public async Task<Caterpillar> UpdateCaterpillar(long id, Caterpillar caterpillar)
        {
            var existingCaterpillar= await _context.Caterpillars.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCaterpillar == null) { return null; }

            existingCaterpillar.X=caterpillar.X;

            existingCaterpillar.Y = caterpillar.Y;

            await _context.SaveChangesAsync();

            return caterpillar;
        }

        
    }
}
