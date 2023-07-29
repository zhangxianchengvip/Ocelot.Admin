using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocelot.Admin.Migrations
{
    public partial class addRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OcelotNameSpace",
                table: "OcelotNameSpace");

            migrationBuilder.RenameTable(
                name: "OcelotNameSpace",
                newName: "OcelotNameSpaces");

            migrationBuilder.RenameIndex(
                name: "IX_OcelotNameSpace_NId",
                table: "OcelotNameSpaces",
                newName: "IX_OcelotNameSpaces_NId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OcelotNameSpaces",
                table: "OcelotNameSpaces",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OcelotRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcelotRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OcelotRoles_Name",
                table: "OcelotRoles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcelotRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OcelotNameSpaces",
                table: "OcelotNameSpaces");

            migrationBuilder.RenameTable(
                name: "OcelotNameSpaces",
                newName: "OcelotNameSpace");

            migrationBuilder.RenameIndex(
                name: "IX_OcelotNameSpaces_NId",
                table: "OcelotNameSpace",
                newName: "IX_OcelotNameSpace_NId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OcelotNameSpace",
                table: "OcelotNameSpace",
                column: "Id");
        }
    }
}
