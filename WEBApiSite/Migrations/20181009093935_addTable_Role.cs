using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WEBApiSite.Migrations
{
    public partial class addTable_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Role",
                columns: table => new
                {
                    roleId = table.Column<string>(maxLength: 32, nullable: false),
                    menuCode = table.Column<string>(maxLength: 32, nullable: true),
                    operateType = table.Column<int>(nullable: false),
                    roleName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Role", x => x.roleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Role");
        }
    }
}
