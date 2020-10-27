using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservices.DataAccess.Migrations
{
    public partial class RefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("47cf6500-026d-4731-938d-ead92afdc429"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("c728093b-2807-4b0e-9696-9f0c3a1d52fe"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("cd440abb-6321-4565-935b-e7185f524430"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("ea01952d-a79d-495f-9f58-ac314335e789"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("eede761d-9ed5-47c9-aa3f-53107354643d"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("f33f5e25-21b6-4ce0-bc53-de8f3c55000d"));

            migrationBuilder.DropColumn(
                name: "MaxBuyGiftLimit",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "MaxBuyLimit",
                table: "aspnetusers");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "aspnetusers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "aspnetusers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "paymentmethod",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("6d0f3519-25ba-473e-8d6d-77bd9cadf2e9"), "VISA" },
                    { new Guid("b60a8d77-2e82-43c5-8476-b10e516524c6"), "Mastercard" },
                    { new Guid("18d1bf6a-9ee3-476e-9047-5b429e231d41"), "KBZ Pay" },
                    { new Guid("2ebbec53-a274-4074-8f0d-51f54cf5f277"), "CB Pay" },
                    { new Guid("798acf84-a8a3-4b16-baf3-f7a97341bf57"), "One Pay" },
                    { new Guid("02d18f1b-5ba8-488b-906d-049d026da4a1"), "WavePay" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_evoucher_PaymentMethodId",
                table: "evoucher",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_evoucher_paymentmethod_PaymentMethodId",
                table: "evoucher",
                column: "PaymentMethodId",
                principalTable: "paymentmethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evoucher_paymentmethod_PaymentMethodId",
                table: "evoucher");

            migrationBuilder.DropIndex(
                name: "IX_evoucher_PaymentMethodId",
                table: "evoucher");

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("02d18f1b-5ba8-488b-906d-049d026da4a1"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("18d1bf6a-9ee3-476e-9047-5b429e231d41"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("2ebbec53-a274-4074-8f0d-51f54cf5f277"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("6d0f3519-25ba-473e-8d6d-77bd9cadf2e9"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("798acf84-a8a3-4b16-baf3-f7a97341bf57"));

            migrationBuilder.DeleteData(
                table: "paymentmethod",
                keyColumn: "Id",
                keyValue: new Guid("b60a8d77-2e82-43c5-8476-b10e516524c6"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "aspnetusers");

            migrationBuilder.AddColumn<int>(
                name: "MaxBuyGiftLimit",
                table: "aspnetusers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxBuyLimit",
                table: "aspnetusers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "paymentmethod",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("c728093b-2807-4b0e-9696-9f0c3a1d52fe"), "VISA" },
                    { new Guid("f33f5e25-21b6-4ce0-bc53-de8f3c55000d"), "Mastercard" },
                    { new Guid("eede761d-9ed5-47c9-aa3f-53107354643d"), "KBZ Pay" },
                    { new Guid("47cf6500-026d-4731-938d-ead92afdc429"), "CB Pay" },
                    { new Guid("cd440abb-6321-4565-935b-e7185f524430"), "One Pay" },
                    { new Guid("ea01952d-a79d-495f-9f58-ac314335e789"), "WavePay" }
                });
        }
    }
}
