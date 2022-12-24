using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetLite.Data.Migrations
{
    /// <inheritdoc />
    public partial class BudgetAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountSpent",
                table: "BudgetPeriods",
                newName: "BudgetAmount");

            migrationBuilder.AddColumn<int>(
                name: "DurationType",
                table: "BudgetPeriods",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationType",
                table: "BudgetPeriods");

            migrationBuilder.RenameColumn(
                name: "BudgetAmount",
                table: "BudgetPeriods",
                newName: "AmountSpent");
        }
    }
}
