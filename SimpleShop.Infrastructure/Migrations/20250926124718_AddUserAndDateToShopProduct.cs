using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndDateToShopProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ShopProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "ShopProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProducts_UserCreatedId",
                table: "ShopProducts",
                column: "UserCreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProducts_AspNetUsers_UserCreatedId",
                table: "ShopProducts",
                column: "UserCreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopProducts_AspNetUsers_UserCreatedId",
                table: "ShopProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShopProducts_UserCreatedId",
                table: "ShopProducts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ShopProducts");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "ShopProducts");
        }
    }
}
