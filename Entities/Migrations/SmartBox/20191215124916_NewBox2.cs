using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations.SmartBox
{
    public partial class NewBox2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasBoxes_SmartBoxes_SmartBoxId",
                table: "OrderHasBoxes");

            migrationBuilder.DropIndex(
                name: "IX_OrderHasBoxes_SmartBoxId",
                table: "OrderHasBoxes");

            migrationBuilder.DropColumn(
                name: "SmartBoxId",
                table: "OrderHasBoxes");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasBoxes_BoxId",
                table: "OrderHasBoxes",
                column: "BoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasBoxes_SmartBoxes_BoxId",
                table: "OrderHasBoxes",
                column: "BoxId",
                principalTable: "SmartBoxes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHasBoxes_SmartBoxes_BoxId",
                table: "OrderHasBoxes");

            migrationBuilder.DropIndex(
                name: "IX_OrderHasBoxes_BoxId",
                table: "OrderHasBoxes");

            migrationBuilder.AddColumn<Guid>(
                name: "SmartBoxId",
                table: "OrderHasBoxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHasBoxes_SmartBoxId",
                table: "OrderHasBoxes",
                column: "SmartBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHasBoxes_SmartBoxes_SmartBoxId",
                table: "OrderHasBoxes",
                column: "SmartBoxId",
                principalTable: "SmartBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
