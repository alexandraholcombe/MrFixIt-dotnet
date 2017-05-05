using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrFixIt.Migrations
{
    public partial class ChangeBooleansToIs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliable",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Pending",
                table: "Jobs");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Workers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Jobs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Jobs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Jobs");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Workers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Jobs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pending",
                table: "Jobs",
                nullable: false,
                defaultValue: false);
        }
    }
}
