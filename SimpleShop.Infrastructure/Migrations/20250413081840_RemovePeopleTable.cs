using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Infrastructure.Migrations;

/// <inheritdoc />
public partial class RemovePeopleTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "People");

        migrationBuilder.DropColumn(
            name: "PersonCreatedId",
            table: "Shops");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "PersonCreatedId",
            table: "Shops",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.CreateTable(
            name: "People",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_People", x => x.Id));
    }
}
