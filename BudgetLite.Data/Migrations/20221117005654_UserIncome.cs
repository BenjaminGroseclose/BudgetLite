using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetLite.Data.Migrations
{
    public partial class UserIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyIncome",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyIncome",
                table: "AspNetUsers");
        }
    }
}
