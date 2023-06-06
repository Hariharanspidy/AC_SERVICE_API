using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC_Service_API.Migrations
{
    /// <inheritdoc />
    public partial class st : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "confirmpassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmpassword",
                table: "Users");
        }
    }
}
