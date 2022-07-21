using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpRobotics.Data.Migrations
{
    public partial class LocationSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BillingAddress_IsDeleted",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShippingAddress_IsDeleted",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress_IsDeleted",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_IsDeleted",
                table: "Customer");
        }
    }
}
