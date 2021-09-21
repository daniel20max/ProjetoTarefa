using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTarefa.Migrations
{
    public partial class clientatt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expired",
                table: "TaskLists");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "TaskLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "TaskLists");

            migrationBuilder.AddColumn<bool>(
                name: "Expired",
                table: "TaskLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
