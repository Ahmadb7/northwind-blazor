using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace northwind_blazor.Persistence.Migrations
{
    public partial class AddingAuditableEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Order Details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Order Details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Order Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Order Details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Employees");
        }
    }
}
