using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommandAPI.Migrations
{
    public partial class AddCommand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandItems",
                columns: table => new
                {
                    CommandId = table.Column<Guid>(nullable: false),
                    HowTo = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    CommandLine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandItems", x => x.CommandId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandItems");
        }
    }
}
