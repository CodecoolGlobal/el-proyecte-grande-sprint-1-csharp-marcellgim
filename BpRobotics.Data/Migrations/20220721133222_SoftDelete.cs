using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpRobotics.Data.Migrations
{
    public partial class SoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Device",
                type: "bit",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Partner",
                type: "bit",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customer");
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Device");
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Partner");
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Service");
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");
        }
    }
}
