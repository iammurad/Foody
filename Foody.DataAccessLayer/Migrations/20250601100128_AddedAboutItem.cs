using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedAboutItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutItems",
                columns: table => new
                {
                    AboutItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutItems", x => x.AboutItemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutItems");
        }
    }
}
