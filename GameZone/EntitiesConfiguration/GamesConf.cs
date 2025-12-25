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
                new Game{Id = 1, Name = "Shadow Strike", Description = "Elite tactical warfare game featuring stealth missions and special forces operations", CategoryId = 1, Cover = "shadow_strike.jpg"},
                new Game{Id = 2, Name = "Battle Nexus", Description = "Futuristic sci-fi shooter with advanced weaponry and intense multiplayer battles", CategoryId = 1, Cover = "battle_nexus.jpg"},
                new Game{Id = 3, Name = "Champions League Ultimate", Description = "Professional football simulation with realistic gameplay and championship tournaments", CategoryId = 2, Cover = "champions_league.jpg"},
                new Game{Id = 4, Name = "Street Soccer Pro", Description = "Urban street football with freestyle tricks and fast-paced arcade action", CategoryId = 2, Cover = "street_soccer.jpg"},
                new Game{Id = 5, Name = "Velocity Rush", Description = "High-speed street racing through neon-lit cities with exotic supercars", CategoryId = 3, Cover = "velocity_rush.jpg"},
                new Game{Id = 6, Name = "Off-Road Legends", Description = "Extreme off-road racing adventure across challenging desert and mountain terrains", CategoryId = 3, Cover = "off_road_legends.jpg"},
            };
        }
    }
}
