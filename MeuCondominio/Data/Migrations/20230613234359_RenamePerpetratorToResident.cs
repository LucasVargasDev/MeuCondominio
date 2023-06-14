using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuCondominio.Data.Migrations
{
    public partial class RenamePerpetratorToResident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perpetrator",
                table: "Occurrence");

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "Occurrence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_ResidentId",
                table: "Occurrence",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Occurrence_Resident_ResidentId",
                table: "Occurrence",
                column: "ResidentId",
                principalTable: "Resident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occurrence_Resident_ResidentId",
                table: "Occurrence");

            migrationBuilder.DropIndex(
                name: "IX_Occurrence_ResidentId",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "Occurrence");

            migrationBuilder.AddColumn<string>(
                name: "Perpetrator",
                table: "Occurrence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
