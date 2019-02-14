using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSimulator.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactionHistories",
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
                    table.PrimaryKey("PK_transactionHistories", x => x.IdTH);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    IdUserInfo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    LiveAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.IdUserInfo);
                });

            migrationBuilder.CreateTable(
                name: "Wealths",
                columns: table => new
                {
                    IdWealth = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cash = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wealths", x => x.IdWealth);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    IdTH = table.Column<int>(nullable: true),
                    IdWealth = table.Column<int>(nullable: true),
                    IdUserInfo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Accounts_transactionHistories_IdTH",
                        column: x => x.IdTH,
                        principalTable: "transactionHistories",
                        principalColumn: "IdTH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_UserInfo_IdUserInfo",
                        column: x => x.IdUserInfo,
                        principalTable: "UserInfo",
                        principalColumn: "IdUserInfo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Wealths_IdWealth",
                        column: x => x.IdWealth,
                        principalTable: "Wealths",
                        principalColumn: "IdWealth",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdTH",
                table: "Accounts",
                column: "IdTH");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdUserInfo",
                table: "Accounts",
                column: "IdUserInfo");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdWealth",
                table: "Accounts",
                column: "IdWealth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "transactionHistories");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Wealths");
        }
    }
}
