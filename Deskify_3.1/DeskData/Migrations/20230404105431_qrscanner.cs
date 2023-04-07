using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeskData.Migrations
{
    public partial class qrscanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_secretKeys_bookingSeats_BookingSeatId",
                table: "secretKeys");

            migrationBuilder.RenameColumn(
                name: "BookingSeatId",
                table: "secretKeys",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_secretKeys_BookingSeatId",
                table: "secretKeys",
                newName: "IX_secretKeys_EmployeeID");

            migrationBuilder.AddColumn<byte[]>(
                name: "QRCode",
                table: "secretKeys",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_secretKeys_employees_EmployeeID",
                table: "secretKeys",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_secretKeys_employees_EmployeeID",
                table: "secretKeys");

            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "secretKeys");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "secretKeys",
                newName: "BookingSeatId");

            migrationBuilder.RenameIndex(
                name: "IX_secretKeys_EmployeeID",
                table: "secretKeys",
                newName: "IX_secretKeys_BookingSeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_secretKeys_bookingSeats_BookingSeatId",
                table: "secretKeys",
                column: "BookingSeatId",
                principalTable: "bookingSeats",
                principalColumn: "BookingSeatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
