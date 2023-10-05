using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CaterpillarControlService.API.Core.Models;
using CaterpillarControlService.API.Infrastructure.ModelConfigurations;

namespace CaterpillarControlService.API.Infrastructure.ApplicationDbContext
{
    public class CaterpillarDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public CaterpillarDbContext(DbContextOptions<CaterpillarDbContext> options,IConfiguration configuration) : base(options)
        {
        }
        public DbSet<ControlStation> ControlStations { get; set; }
        public DbSet<Caterpillar> Caterpillars { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Spice> Spices { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<UserControlStation> UserControlStations { get; set; }
        public DbSet<DeviceInformation>DeviceInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ControlStationConfiguration());
            builder.ApplyConfiguration(new PlanetConfiguration());
            builder.ApplyConfiguration(new CaterpillarConfiguration());
            builder.ApplyConfiguration(new GecaInformationConfiguration());
            builder.ApplyConfiguration(new ShiftConfiguration());
        }
    }
}
