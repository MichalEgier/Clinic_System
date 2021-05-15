using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class AddedCabinets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Cabinet_VisitCabinetCabinetID",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabinet",
                table: "Cabinet");

            migrationBuilder.RenameTable(
                name: "Cabinet",
                newName: "Cabinets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabinets",
                table: "Cabinets",
                column: "CabinetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Cabinets_VisitCabinetCabinetID",
                table: "Visits",
                column: "VisitCabinetCabinetID",
                principalTable: "Cabinets",
                principalColumn: "CabinetID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Cabinets_VisitCabinetCabinetID",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabinets",
                table: "Cabinets");

            migrationBuilder.RenameTable(
                name: "Cabinets",
                newName: "Cabinet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabinet",
                table: "Cabinet",
                column: "CabinetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Cabinet_VisitCabinetCabinetID",
                table: "Visits",
                column: "VisitCabinetCabinetID",
                principalTable: "Cabinet",
                principalColumn: "CabinetID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
