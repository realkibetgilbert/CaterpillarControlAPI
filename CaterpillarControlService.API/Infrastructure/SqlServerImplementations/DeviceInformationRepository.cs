using CaterpillarControlService.API.Core.Interfaces;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace CaterpillarControlService.API.Infrastructure.SqlServerImplementations
{
    public class DeviceInformationRepository : IDeviceInformationRepository
    {
        private readonly CaterpillarDbContext _context;

        public DeviceInformationRepository(CaterpillarDbContext context)
        {
           _context = context;
        }
        public async Task<List<DeviceInformation>> GetDeviceInformation()
        {
            return await _context.DeviceInformations.ToListAsync();
        }
    }
}
