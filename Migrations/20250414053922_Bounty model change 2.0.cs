using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_2025_Filipino_Homes.Migrations
{
    /// <inheritdoc />
    public partial class Bountymodelchange20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_account_BountyId",
                table: "account");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "bounty",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_account_BountyId",
                table: "account",
                column: "BountyId",
                unique: true,
                filter: "[BountyId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_account_BountyId",
                table: "account");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "bounty");

            migrationBuilder.CreateIndex(
                name: "IX_account_BountyId",
                table: "account",
                column: "BountyId");
        }
    }
}
