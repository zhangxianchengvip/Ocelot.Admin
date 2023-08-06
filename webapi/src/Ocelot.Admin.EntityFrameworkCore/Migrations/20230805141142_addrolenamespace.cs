using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocelot.Admin.Migrations
{
    public partial class addrolenamespace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OcelotRoleNameSpace",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSpaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcelotRoleNameSpace", x => new { x.RoleId, x.NameSpaceId });
                    table.ForeignKey(
                        name: "FK_OcelotRoleNameSpace_OcelotRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OcelotRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcelotRoleNameSpace");
        }
    }
}
