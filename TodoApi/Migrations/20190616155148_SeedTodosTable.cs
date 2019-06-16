using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class SeedTodosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Key", "IsCompleted", "Name" },
                values: new object[] { "7b2569ab-3771-42bd-ac0a-4ad6c52a2c95", false, "Initial Value" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Key",
                keyValue: "7b2569ab-3771-42bd-ac0a-4ad6c52a2c95");
        }
    }
}
