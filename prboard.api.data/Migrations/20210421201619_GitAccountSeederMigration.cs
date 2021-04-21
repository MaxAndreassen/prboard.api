using System;
using Microsoft.EntityFrameworkCore.Migrations;
using prboard.api.data.Users.Enums;

namespace prboard.api.data.Migrations
{
    public partial class GitAccountSeederMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GitAccountSources",
                columns: new[]
                    {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Type"},
                values: new object[]
                {
                    1, new Guid("4225f111-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null,
                    "GitHub", (int) GitAccountType.GitHub
                }
            );
            
            migrationBuilder.InsertData(
                table: "GitAccountSources",
                columns: new[]
                    {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Type"},
                values: new object[]
                {
                    2, new Guid("5225f111-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null,
                    "BitBucket", (int) GitAccountType.BitBucket
                }
            );
            
            migrationBuilder.InsertData(
                table: "GitAccountSources",
                columns: new[]
                    {"Id", "Uuid", "CreatedAt", "UpdatedAt", "DeletedAt", "Name", "Type"},
                values: new object[]
                {
                    3, new Guid("6225f111-f5e6-4da0-8231-280ebf07161f"), DateTime.Now, null, null,
                    "GitLab", (int) GitAccountType.GitLab
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
