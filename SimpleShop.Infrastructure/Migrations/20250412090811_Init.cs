using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleShop.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "People",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_People", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Shops",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                PersonCreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Shops", x => x.Id));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "People");

        migrationBuilder.DropTable(
            name: "Shops");
    }
}
