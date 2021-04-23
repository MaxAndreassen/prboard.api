using Microsoft.EntityFrameworkCore.Migrations;

namespace prboard.api.data.Migrations
{
    public partial class GitAccountUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceUserIdentifier",
                table: "UserGitAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceUserIdentifier",
                table: "UserGitAccounts");
        }
    }
}
