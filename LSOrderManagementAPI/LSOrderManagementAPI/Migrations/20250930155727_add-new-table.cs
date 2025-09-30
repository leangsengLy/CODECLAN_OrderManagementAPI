using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSOrderManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class addnewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LSCUSTOMER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EN_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GENDER = table.Column<bool>(type: "bit", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PHONE1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DB_CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSCUSTOMER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LSITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SUB_TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DB_CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LSORDER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CUS_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSORDER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LSORDER_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    ITEM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSORDER_ITEM", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LSCUSTOMER");

            migrationBuilder.DropTable(
                name: "LSITEM");

            migrationBuilder.DropTable(
                name: "LSORDER");

            migrationBuilder.DropTable(
                name: "LSORDER_ITEM");
        }
    }
}
