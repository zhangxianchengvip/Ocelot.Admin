using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocelot.Admin.Migrations
{
    public partial class addRole_candelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanBeDeleted",
                table: "OcelotRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanBeDeleted",
                table: "OcelotRoles");
        }
    }
}
