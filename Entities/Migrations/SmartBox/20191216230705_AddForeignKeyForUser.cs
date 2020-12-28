using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations.SmartBox
{
    public partial class AddForeignKeyForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasBoxes_Orders_OrderId",
                table: "OrderHasBoxes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderHasBoxes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasBoxes_Orders_OrderId",
                table: "OrderHasBoxes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasBoxes_Orders_OrderId",
                table: "OrderHasBoxes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderHasBoxes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasBoxes_Orders_OrderId",
                table: "OrderHasBoxes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
