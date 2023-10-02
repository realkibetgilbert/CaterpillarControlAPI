using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Infrastructure.ApplicationDbContext
{
    public class CaterpillarDbContext : IdentityDbContext<Rider, IdentityRole<long>, long>
    {
        public CaterpillarDbContext(DbContextOptions<CaterpillarDbContext> options) : base(options)
        {
        }
        public DbSet<ControlStation> ControlStations { get; set; }
        public DbSet<Caterpillar> Caterpillars { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Spice> Spices { get; set; }
    }
}
