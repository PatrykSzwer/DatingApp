using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Model.Migrations
{
    public partial class AddBaseEntityWithCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Values",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Values");
        }
    }
}
