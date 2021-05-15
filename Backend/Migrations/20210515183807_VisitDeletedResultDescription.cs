using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class VisitDeletedResultDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitResultDescription",
                table: "Visits");

            migrationBuilder.CreateTable(
                name: "VisitDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    VisitCabinet = table.Column<int>(type: "int", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientPrevisitNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitDTO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitDTO");

            migrationBuilder.AddColumn<string>(
                name: "VisitResultDescription",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
