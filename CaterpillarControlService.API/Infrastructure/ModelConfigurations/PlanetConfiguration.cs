using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class PlanetConfiguration:IEntityTypeConfiguration<Planet>
    {

       

       
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
           

            builder.HasData(
                new Planet
                {
                    Id = 1,
                    Name ="Distant",
                    Height = 30,
                    Width = 30
                }
                );
        }
    }
}
