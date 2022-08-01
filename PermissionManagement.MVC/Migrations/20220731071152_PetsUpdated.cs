using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionManagement.MVC.Migrations
{
    public partial class PetsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdoptionCenterId",
                table: "Pet",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_AdoptionCenterId",
                table: "Pet",
                column: "AdoptionCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_AdoptionCenter_AdoptionCenterId",
                table: "Pet",
                column: "AdoptionCenterId",
                principalTable: "AdoptionCenter",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_AdoptionCenter_AdoptionCenterId",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_AdoptionCenterId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "AdoptionCenterId",
                table: "Pet");
        }
    }
}
