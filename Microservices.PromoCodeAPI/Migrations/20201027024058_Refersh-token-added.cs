using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservices.PromoCodeAPI.Migrations
{
    public partial class Refershtokenadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "aspnetusers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "aspnetusers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "aspnetusers");
        }
    }
}
