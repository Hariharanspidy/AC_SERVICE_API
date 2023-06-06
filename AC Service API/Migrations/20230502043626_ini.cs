using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC_Service_API.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductModelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    availableSlots = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceCenterID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceCenterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceCenterPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceCenterAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceCenterImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceCenteramailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
