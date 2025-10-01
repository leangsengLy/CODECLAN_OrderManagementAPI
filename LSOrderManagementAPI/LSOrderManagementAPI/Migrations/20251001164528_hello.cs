using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSOrderManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_LSCUSTOMER",
                table: "LSCUSTOMER",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LSCUSTOMER",
                table: "LSCUSTOMER");
        }
    }
}
