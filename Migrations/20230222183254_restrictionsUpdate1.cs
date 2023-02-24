using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicStore.Migrations
{
    /// <inheritdoc />
    public partial class restrictionsUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Stores_StoreId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Finances_Stores_store_id",
                table: "Finances");

            migrationBuilder.DropForeignKey(
                name: "FK_StorePermissions_Users_UserId",
                table: "StorePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStorePermissions_StorePermissions_PermissionId",
                table: "UserStorePermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserStorePermissions_PermissionId",
                table: "UserStorePermissions");

            migrationBuilder.DropIndex(
                name: "IX_StorePermissions_UserId",
                table: "StorePermissions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StoreId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StorePermissions");

            migrationBuilder.RenameColumn(
                name: "store_id",
                table: "Finances",
                newName: "StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Finances_store_id",
                table: "Finances",
                newName: "IX_Finances_StoreId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_Stores_StoreId",
                table: "Finances",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Finances_Stores_StoreId",
                table: "Finances");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Finances",
                newName: "store_id");

            migrationBuilder.RenameIndex(
                name: "IX_Finances_StoreId",
                table: "Finances",
                newName: "IX_Finances_store_id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StorePermissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStorePermissions_PermissionId",
                table: "UserStorePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePermissions_UserId",
                table: "StorePermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StoreId",
                table: "Employees",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Stores_StoreId",
                table: "Employees",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_Stores_store_id",
                table: "Finances",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorePermissions_Users_UserId",
                table: "StorePermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStorePermissions_StorePermissions_PermissionId",
                table: "UserStorePermissions",
                column: "PermissionId",
                principalTable: "StorePermissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
