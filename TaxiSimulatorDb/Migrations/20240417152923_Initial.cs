using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiSimulatorDb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeparturePoint = table.Column<string>(type: "TEXT", nullable: true),
                    DestinationPoint = table.Column<string>(type: "TEXT", nullable: true),
                    Distance = table.Column<int>(type: "INTEGER", nullable: true),
                    Plan = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: true),
                    StartTime = table.Column<long>(type: "INTEGER", nullable: true),
                    EndTime = table.Column<long>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<long>(type: "INTEGER", nullable: true),
                    WaitingStartedAt = table.Column<long>(type: "INTEGER", nullable: true),
                    DriveStartedAt = table.Column<long>(type: "INTEGER", nullable: true),
                    CompletedAt = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
