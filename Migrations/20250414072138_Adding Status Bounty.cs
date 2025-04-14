using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_2025_Filipino_Homes.Migrations
{
    /// <inheritdoc />
    public partial class AddingStatusBounty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "bounty",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "bounty");
        }
    }
}
