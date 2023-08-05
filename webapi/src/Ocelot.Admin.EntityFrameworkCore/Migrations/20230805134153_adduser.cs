using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocelot.Admin.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OcelotUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcelotUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OcelotUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcelotUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_OcelotUserRole_OcelotUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "OcelotUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcelotUserRole");

            migrationBuilder.DropTable(
                name: "OcelotUsers");
        }
    }
}
