using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class GecaInformationConfiguration:IEntityTypeConfiguration<DeviceInformation>
    {
        public void Configure(EntityTypeBuilder<DeviceInformation> builder)
        {
            builder.HasData(
               new DeviceInformation
               {
                  Id = 1,
                  batteryPercentage = 90.0,
                  deviceId="1"
               }
               );
        }
    }
}
