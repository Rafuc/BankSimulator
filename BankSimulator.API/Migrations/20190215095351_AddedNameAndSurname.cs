using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSimulator.API.Migrations
{
    public partial class AddedNameAndSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IdTH = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Accounts_TransactionHistories_IdTH",
                        column: x => x.IdTH,
                        principalTable: "TransactionHistories",
                        principalColumn: "IdTH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdTH",
                table: "Accounts",
                column: "IdTH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TransactionHistories");
        }
    }
}
