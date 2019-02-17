using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSimulator.API.Migrations
{
    public partial class EdgedMaximallCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_CreditHistory_CreditHistoriesIDCredit",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditHistory",
                table: "CreditHistory");

            migrationBuilder.RenameTable(
                name: "CreditHistory",
                newName: "CreditHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditHistories",
                table: "CreditHistories",
                column: "IDCredit");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_CreditHistories_CreditHistoriesIDCredit",
                table: "Accounts",
                column: "CreditHistoriesIDCredit",
                principalTable: "CreditHistories",
                principalColumn: "IDCredit",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_CreditHistories_CreditHistoriesIDCredit",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditHistories",
                table: "CreditHistories");

            migrationBuilder.RenameTable(
                name: "CreditHistories",
                newName: "CreditHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditHistory",
                table: "CreditHistory",
                column: "IDCredit");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_CreditHistory_CreditHistoriesIDCredit",
                table: "Accounts",
                column: "CreditHistoriesIDCredit",
                principalTable: "CreditHistory",
                principalColumn: "IDCredit",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
