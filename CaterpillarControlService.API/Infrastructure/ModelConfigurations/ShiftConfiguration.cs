using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {

            builder
            .HasOne(s => s.ControlStation)
            .WithMany()
            .HasForeignKey(s => s.ControlStationId);

            builder
         .HasMany(s => s.Spices)
         .WithOne(t => t.Shift)
         .HasForeignKey(t => t.ShiftId)
         .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
