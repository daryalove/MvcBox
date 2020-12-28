using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations.SmartBox
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddForeignKey("FK_Drivers_User_AccountId",
            //   "Drivers", "AccountId",
            //   "AspNetUsers", principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey("FK_UserHasAccesses_User_UserId",
                "UserHasAccesses", "UserId",
                "AspNetUsers", principalColumn: "Id",
                 onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey("FK_UserHasOrders_User_UserId",
               "UserHasOrders", "UserId",
               "AspNetUsers", principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey("FK_Drivers_User_AccountId",
            //    "AccountId", "Drivers");

            migrationBuilder.DropForeignKey("FK_UserHasAccesses_User_UserId",
                "UserId", "UserHasAccesses");

            migrationBuilder.DropForeignKey("FK_UserHasOrders_User_UserId",
               "UserId", "UserHasOrders");
        }
    }
}
