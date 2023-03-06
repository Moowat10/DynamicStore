using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Migrations
{
    /// <inheritdoc />
    public partial class fixNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Stores_StoreId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_StoreId",
                table: "Warehouses");

            migrationBuilder.AlterColumn<string>(
                name: "StoreId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Warehouses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_StoreId",
                table: "Warehouses",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Stores_StoreId",
                table: "Warehouses",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId");
        }
    }
}
