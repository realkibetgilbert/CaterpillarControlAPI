using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class ControlStationConfiguration: IEntityTypeConfiguration<ControlStation>
    {
        public void Configure(EntityTypeBuilder<ControlStation> builder)
        {
            builder.Property(t => t.IsActive).HasDefaultValue(true);
            builder.HasData(
               new ControlStation
               {
                   Id = 1,
                   Name="A",
                   IsActive= true,
               }
               );
        }
    }
}
