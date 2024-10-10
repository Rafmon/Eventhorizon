using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventHorizon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EventStart = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    EventEnd = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    IsEventStartRandom = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEventEndRandom = table.Column<bool>(type: "INTEGER", nullable: false),
                    EventStartOffset = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    EventEndOffset = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Address = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemoryAddresses",
                columns: table => new
                {
                    Address = table.Column<int>(type: "INTEGER", nullable: false),                        
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryAddresses", x => x.Address);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MemoryAddresses");
        }
    }
}
