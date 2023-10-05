using CaterpillarControlService.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CaterpillarControlService.API.Infrastructure.ModelConfigurations
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasData(
                new Planet
                {
                    Id = 1,
                    Name = "Distant",
                    Height = 30,
                    Width = 30
                }
                );
            var random = new Random();

            var spices = new List<Spice>();

            for (int i = 0; i < 10; i++) 
            {
                int x = random.Next(0, 30); 
                int y = random.Next(0, 30); 

                var spice = new Spice
                {
                    Id = i + 1, 
                    Name = $"Spice{i + 1}",
                    X = x,
                    Y = y
                };

                spices.Add(spice);
            }

            builder.HasMany(p => p.Spices);
        }
    }

}
