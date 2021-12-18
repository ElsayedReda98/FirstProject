using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreConsoleApp.Migrations
{
    public partial class update_relation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Stores_StoreId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_StoreId",
                table: "Staffs");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ManagerId",
                table: "Staffs",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Stores_ManagerId",
                table: "Staffs",
                column: "ManagerId",
                principalTable: "Stores",
                principalColumn: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Stores_ManagerId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_ManagerId",
                table: "Staffs");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StoreId",
                table: "Staffs",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Stores_StoreId",
                table: "Staffs",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
