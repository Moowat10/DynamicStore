using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Migrations
{
    /// <inheritdoc />
    public partial class fixNewTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_StoreId",
                table: "Warehouses",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Stores_StoreId",
                table: "Warehouses",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Stores_StoreId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_StoreId",
                table: "Warehouses");
        }
    }
}
