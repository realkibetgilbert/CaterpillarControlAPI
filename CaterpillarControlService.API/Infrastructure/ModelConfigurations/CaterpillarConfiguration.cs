using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class CaterpillarConfiguration : IEntityTypeConfiguration<Caterpillar>
    {
        public void Configure(EntityTypeBuilder<Caterpillar> builder)
        {


            builder.HasData(
                new Caterpillar
                {
                    Id = 1,
                    Name = "Caterpillar  A",
                    Length = 10,
                    X = 0,
                    Y = 0,
                }
                );
        }
    }
}
