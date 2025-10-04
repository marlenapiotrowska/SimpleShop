using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddUserCreatedIdToShopTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "UserCreatedId",
            table: "Shops",
            type: "nvarchar(450)",
            nullable: false,
            defaultValue: "00000000-0000-0000-0000-000000000000");

        migrationBuilder.DropPrimaryKey(
            name: "PK_AspNetUserTokens",
            table: "AspNetUserTokens");

        migrationBuilder.DropPrimaryKey(
            name: "PK_AspNetUserLogins",
            table: "AspNetUserLogins");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "AspNetUserTokens",
            type: "nvarchar(128)",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)");

        migrationBuilder.AlterColumn<string>(
            name: "LoginProvider",
            table: "AspNetUserTokens",
            type: "nvarchar(128)",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)");

        migrationBuilder.AlterColumn<string>(
            name: "ProviderKey",
            table: "AspNetUserLogins",
            type: "nvarchar(128)",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)");

        migrationBuilder.AlterColumn<string>(
            name: "LoginProvider",
            table: "AspNetUserLogins",
            type: "nvarchar(128)",
            maxLength: 128,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)");

        migrationBuilder.AddPrimaryKey(
            name: "PK_AspNetUserTokens",
            table: "AspNetUserTokens",
            columns: ["UserId", "LoginProvider", "Name"]);

        migrationBuilder.AddPrimaryKey(
            name: "PK_AspNetUserLogins",
            table: "AspNetUserLogins",
            columns: ["LoginProvider", "ProviderKey"]);

        migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM AspNetUsers WHERE Id = '00000000-0000-0000-0000-000000000000')
                BEGIN
                    INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
                    VALUES ('00000000-0000-0000-0000-000000000000', 'system', 'SYSTEM', 1, '', NEWID(), NEWID(), 0, 0, 0, 0)
                END
                ");

        migrationBuilder.CreateIndex(
            name: "IX_Shops_UserCreatedId",
            table: "Shops",
            column: "UserCreatedId");

        migrationBuilder.AddForeignKey(
            name: "FK_Shops_AspNetUsers_UserCreatedId",
            table: "Shops",
            column: "UserCreatedId",
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Shops_AspNetUsers_UserCreatedId",
            table: "Shops");

        migrationBuilder.DropIndex(
            name: "IX_Shops_UserCreatedId",
            table: "Shops");

        migrationBuilder.DropColumn(
            name: "UserCreatedId",
            table: "Shops");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "AspNetUserTokens",
            type: "nvarchar(450)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(128)",
            oldMaxLength: 128);

        migrationBuilder.AlterColumn<string>(
            name: "LoginProvider",
            table: "AspNetUserTokens",
            type: "nvarchar(450)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(128)",
            oldMaxLength: 128);

        migrationBuilder.AlterColumn<string>(
            name: "ProviderKey",
            table: "AspNetUserLogins",
            type: "nvarchar(450)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(128)",
            oldMaxLength: 128);

        migrationBuilder.AlterColumn<string>(
            name: "LoginProvider",
            table: "AspNetUserLogins",
            type: "nvarchar(450)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(128)",
            oldMaxLength: 128);
    }
}
