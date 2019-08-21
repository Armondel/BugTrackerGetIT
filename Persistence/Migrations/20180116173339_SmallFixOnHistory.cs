using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BugTrackerGetIT.WebApp.Data.Migrations
{
    public partial class SmallFixOnHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "StatusId",
                table: "BugHistory",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_BugHistory_StatusId",
                table: "BugHistory",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BugHistory_Status_StatusId",
                table: "BugHistory",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugHistory_Status_StatusId",
                table: "BugHistory");

            migrationBuilder.DropIndex(
                name: "IX_BugHistory_StatusId",
                table: "BugHistory");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "BugHistory");
        }
    }
}
