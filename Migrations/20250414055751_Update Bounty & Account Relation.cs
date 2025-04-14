using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_2025_Filipino_Homes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBountyAccountRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_bounty_BountyId",
                table: "account");

            migrationBuilder.DropIndex(
                name: "IX_account_BountyId",
                table: "account");

            migrationBuilder.DropColumn(
                name: "BountyId",
                table: "account");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "bounty",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bounty_AccountId",
                table: "bounty",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_bounty_account_AccountId",
                table: "bounty",
                column: "AccountId",
                principalTable: "account",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bounty_account_AccountId",
                table: "bounty");

            migrationBuilder.DropIndex(
                name: "IX_bounty_AccountId",
                table: "bounty");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "bounty");

            migrationBuilder.AddColumn<string>(
                name: "BountyId",
                table: "account",
                type: "nvarchar(450)",
                nullable: true);

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
        }
    }
}
