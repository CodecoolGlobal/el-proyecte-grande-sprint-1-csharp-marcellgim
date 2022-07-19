using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpRobotics.Data.Migrations
{
    public partial class AddPartnerServiceNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_PartnerId",
                table: "Service",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Partner_PartnerId",
                table: "Service",
                column: "PartnerId",
                principalTable: "Partner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Partner_PartnerId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_PartnerId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Service");
        }
    }
}
