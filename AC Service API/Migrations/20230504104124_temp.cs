using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC_Service_API.Migrations
{
    /// <inheritdoc />
    public partial class temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "serviceCenterID",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "serviceCenterID",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
