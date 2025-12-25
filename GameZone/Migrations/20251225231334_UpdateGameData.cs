using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cover", "Description", "Name" },
                values: new object[] { "shadow_strike.jpg", "Elite tactical warfare game featuring stealth missions and special forces operations", "Shadow Strike" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Cover", "Description", "Name" },
                values: new object[] { 1, "battle_nexus.jpg", "Futuristic sci-fi shooter with advanced weaponry and intense multiplayer battles", "Battle Nexus" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Cover", "Description", "Name" },
                values: new object[] { 2, "champions_league.jpg", "Professional football simulation with realistic gameplay and championship tournaments", "Champions League Ultimate" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cover", "Description", "Name" },
                values: new object[] { "street_soccer.jpg", "Urban street football with freestyle tricks and fast-paced arcade action", "Street Soccer Pro" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cover", "Description", "Name" },
                values: new object[] { "velocity_rush.jpg", "High-speed street racing through neon-lit cities with exotic supercars", "Velocity Rush" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Cover", "Description", "Name" },
                values: new object[] { 3, "off_road_legends.jpg", "Extreme off-road racing adventure across challenging desert and mountain terrains", "Off-Road Legends" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cover", "Description", "Name" },
                values: new object[] { null, "FootBall Game", "FIFA 2024" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Cover", "Description", "Name" },
                values: new object[] { 2, null, "FootBall Game", "Pease 2024" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Cover", "Description", "Name" },
                values: new object[] { 3, null, "IGI Ware Game", "IGI" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cover", "Description", "Name" },
                values: new object[] { null, "Pubgi its Ware Game", "Pubgi" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cover", "Description", "Name" },
                values: new object[] { null, "GTA Car Game", "GTA" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Cover", "Description", "Name" },
                values: new object[] { 1, null, "Midetown Car Game", "Midetown" });
        }
    }
}
