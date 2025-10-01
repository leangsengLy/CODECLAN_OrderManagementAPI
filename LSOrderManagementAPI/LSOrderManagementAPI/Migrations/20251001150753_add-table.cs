using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSOrderManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
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
                    UPDATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DB_CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
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
                    UPDATED_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DB_CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LSLOGIN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    USER_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE_REGISTER = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSLOGIN", x => x.ID);
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
                    ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LSORDER_ITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderQueryDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerGender = table.Column<bool>(type: "bit", nullable: false),
                    CustomerEMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
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
                name: "LSLOGIN");

            migrationBuilder.DropTable(
                name: "LSORDER");

            migrationBuilder.DropTable(
                name: "LSORDER_ITEM");

            migrationBuilder.DropTable(
                name: "OrderQueryDtos");
        }
    }
}
