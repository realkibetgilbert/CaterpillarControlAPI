using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasMany(S => S.Shifts).WithOne(U => U.Rider).HasForeignKey(U => U.RiderId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.IsActive).HasDefaultValue(true);
          
        }
    }
}
