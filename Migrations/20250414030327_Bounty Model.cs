using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_2025_Filipino_Homes.Migrations
{
    /// <inheritdoc />
    public partial class BountyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BountyId",
                table: "users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BountyId",
                table: "account",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bounty",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reward = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bounty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_BountyId",
                table: "users",
                column: "BountyId");

            migrationBuilder.CreateIndex(
                name: "IX_account_BountyId",
                table: "account",
                column: "BountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_account_bounty_BountyId",
                table: "account",
                column: "BountyId",
                principalTable: "bounty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_bounty_BountyId",
                table: "users",
                column: "BountyId",
                principalTable: "bounty",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_bounty_BountyId",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_users_bounty_BountyId",
                table: "users");

            migrationBuilder.DropTable(
                name: "bounty");

            migrationBuilder.DropIndex(
                name: "IX_users_BountyId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_account_BountyId",
                table: "account");

            migrationBuilder.DropColumn(
                name: "BountyId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "BountyId",
                table: "account");
        }
    }
}
