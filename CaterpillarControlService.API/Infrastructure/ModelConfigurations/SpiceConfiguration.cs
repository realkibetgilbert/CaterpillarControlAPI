using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class SpiceConfiguration : IEntityTypeConfiguration<Spice>
    {
        public void Configure(EntityTypeBuilder<Spice> builder)
        {
          
            builder.HasIndex(e => e.Reference).IsUnique();
        }
    }
}
