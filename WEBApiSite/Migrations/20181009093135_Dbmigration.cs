using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WEBApiSite.Migrations
{
    public partial class Dbmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_User",
                columns: table => new
                {
                    userName = table.Column<string>(maxLength: 32, nullable: false),
                    lastLoginTime = table.Column<DateTime>(nullable: false),
                    loginCount = table.Column<int>(nullable: false),
                    passWord = table.Column<string>(maxLength: 32, nullable: false),
                    status = table.Column<int>(nullable: false),
                    userId = table.Column<string>(maxLength: 32, nullable: false),
                    userRole = table.Column<string>(maxLength: 32, nullable: true),
                    wrongCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_User", x => x.userName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_User");
        }
    }
}
