using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcelotAdmin.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCanBeDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_App_UserRoles_App_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "App_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Roles_Id",
                table: "App_Roles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_App_Users_Id",
                table: "App_Users",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Roles");

            migrationBuilder.DropTable(
                name: "App_Tests");

            migrationBuilder.DropTable(
                name: "App_UserRoles");

            migrationBuilder.DropTable(
                name: "App_Users");
        }
    }
}
