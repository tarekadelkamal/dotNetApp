 using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;


namespace GameZone.EntitiesConfiguration
{
    public class GamesConf : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(e => e.Cover).HasColumnType("Nvarchar");
            builder.Property(e => e.Cover).HasMaxLength(500);
            builder.HasOne(t => t.Category)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.CategoryId);

            builder.HasMany(w => w.Devices)
                .WithOne(w => w.Game);

             

            builder.HasData(LoadData());
        }

        public List<Game> LoadData()
        {
            return new List<Game>
            {
                new Game{Id = 1, Name = "FIFA 2024", Description = "FootBall Game", CategoryId = 1, Cover = "0b7d417b-a940-42de-8082-943fa90a33c4.jpg"},
                new Game{Id = 2, Name = "Pease 2024", Description = "FootBall Game", CategoryId = 2, Cover ="19fa8dd2-8b82-4782-b3c8-690990e9f655.jpg"},
                new Game{Id = 3, Name = "IGI", Description = "IGI Ware Game", CategoryId = 3, Cover = "a12bb8d4-2da0-4aa2-a45e-2d7fab94e805.jpg"},
                new Game{Id = 4, Name = "Pubgi", Description = "Pubgi its Ware Game", CategoryId = 2, Cover = "a12bb8d4-2da0-4aa2-a45e-2d7fab94e805.jpg"},
                new Game{Id = 5, Name = "GTA", Description = "GTA Car Game", CategoryId = 3, Cover = "a12bb8d4-2da0-4aa2-a45e-2d7fab94e805.jpg"},
                new Game{Id = 6, Name = "Midetown", Description = "Midetown Car Game", CategoryId = 1, Cover = "35c30395-9213-4105-810e-678ab24dfd8c.jpg"},
            };
        }
    }
}
