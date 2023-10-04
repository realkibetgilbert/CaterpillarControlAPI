using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Dtos.Caterpillar;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
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

        public Bitmap GenerateRadarImage(Caterpillar caterpillar)
        {
            
            
            int radarDiameter = 11; 
            int radarPixelSize = 1;
            int radarWidth = radarDiameter * radarPixelSize;
            int radarHeight = radarDiameter * radarPixelSize;


            int enlargedWidth = radarWidth * 2; 
            int enlargedHeight = radarHeight * 2; 
            var radarImage = new Bitmap(enlargedWidth, enlargedHeight);

           // var radarImage = new Bitmap(radarWidth, radarHeight);

            using (var graphics = Graphics.FromImage(radarImage))
            {
              
                graphics.Clear(Color.Black);

               
                int headX = caterpillar.X;
                int headY = caterpillar.Y;
                int caterpillarLength = caterpillar.Length;
                int tailX = headX - caterpillarLength;

                
                var segmentColor = Brushes.Black;
                var segmentFont = new Font("Arial", 10);

               
                graphics.DrawString("H", segmentFont, segmentColor, new PointF(headX, headY));

               
                graphics.DrawString("T", segmentFont, segmentColor, new PointF(tailX, headY));

                
                for (int i = 1; i < caterpillarLength; i++)
                {
                    int intermediateX = tailX + i;
                    graphics.DrawString("0", segmentFont, segmentColor, new PointF(intermediateX, headY));
                }

                radarImage.Save("radar.png"); 
            }

            return radarImage;
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
                case DirectionType.U:
                    newY -= movementDto.Distance;
                    break;
                case DirectionType.D:
                    newY += movementDto.Distance;
                    break;
                case DirectionType.L:
                    newX -= movementDto.Distance;
                    break;
                case DirectionType.R:
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
