using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Infrastructure.ApplicationDbContext
{
    public class CaterpillarDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public CaterpillarDbContext(DbContextOptions<CaterpillarDbContext> options) : base(options)
        {
        }
        public DbSet<ControlStation> ControlStations { get; set; }
        public DbSet<Caterpillar> Caterpillars { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Spice> Spices { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<UserControlStation> UserControlStations { get; set; }


    }
}
