using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_2025_Filipino_Homes.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBountyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_bounty_BountyId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_BountyId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "BountyId",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BountyId",
                table: "users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_BountyId",
                table: "users",
                column: "BountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_bounty_BountyId",
                table: "users",
                column: "BountyId",
                principalTable: "bounty",
                principalColumn: "Id");
        }
    }
}
