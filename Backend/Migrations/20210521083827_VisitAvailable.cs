using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class VisitAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitAvailabilityId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VisitAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitAvailability", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VisitAvailabilityId",
                table: "Doctors",
                column: "VisitAvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_VisitAvailability_VisitAvailabilityId",
                table: "Doctors",
                column: "VisitAvailabilityId",
                principalTable: "VisitAvailability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VisitAvailability_VisitAvailabilityId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "VisitAvailability");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_VisitAvailabilityId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "VisitAvailabilityId",
                table: "Doctors");
        }
    }
}
