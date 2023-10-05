using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {


            builder.HasData(
                new Shift
                {
                    Id = 1,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                }
                );
        }
    }
}
