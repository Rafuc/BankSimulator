using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSimulator.API.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditHistory",
                columns: table => new
                {
                    IDCredit = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditAmmount = table.Column<decimal>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    RateOfIntrest = table.Column<int>(nullable: false),
                    CreditPaymentTime = table.Column<string>(nullable: true),
                    RemainingCredit = table.Column<decimal>(nullable: false),
                    IDPersonTakinCredit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditHistory", x => x.IDCredit);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistories",
                columns: table => new
                {
                    IdTH = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoneyBefore = table.Column<decimal>(nullable: false),
                    MoneyAfter = table.Column<decimal>(nullable: false),
                    TitleOfTransaction = table.Column<string>(nullable: true),
                    IdTransactionReceiver = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistories", x => x.IdTH);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    LiveAddress = table.Column<string>(nullable: true),
                    Cash = table.Column<decimal>(nullable: false),
                    CreditHistoriesIDCredit = table.Column<int>(nullable: true),
                    TransactionHistorysIdTH = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Accounts_CreditHistory_CreditHistoriesIDCredit",
                        column: x => x.CreditHistoriesIDCredit,
                        principalTable: "CreditHistory",
                        principalColumn: "IDCredit",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_TransactionHistories_TransactionHistorysIdTH",
                        column: x => x.TransactionHistorysIdTH,
                        principalTable: "TransactionHistories",
                        principalColumn: "IdTH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreditHistoriesIDCredit",
                table: "Accounts",
                column: "CreditHistoriesIDCredit");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TransactionHistorysIdTH",
                table: "Accounts",
                column: "TransactionHistorysIdTH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CreditHistory");

            migrationBuilder.DropTable(
                name: "TransactionHistories");
        }
    }
}
