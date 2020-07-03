using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Server.Data.Migrations
{
    public partial class Split_User_and_UserSS_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_UserSSes_SellerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserSSes_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserSSes_CreatorId",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "UserSSId",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSSId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSSId",
                table: "Listings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserSSId",
                table: "Offers",
                column: "UserSSId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserSSId",
                table: "Messages",
                column: "UserSSId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UserSSId",
                table: "Listings",
                column: "UserSSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_SellerId",
                table: "Listings",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_UserSSes_UserSSId",
                table: "Listings",
                column: "UserSSId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserSSes_UserSSId",
                table: "Messages",
                column: "UserSSId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_CreatorId",
                table: "Offers",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_UserSSes_UserSSId",
                table: "Offers",
                column: "UserSSId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_SellerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_UserSSes_UserSSId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserSSes_UserSSId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_CreatorId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserSSes_UserSSId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_UserSSId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserSSId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Listings_UserSSId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "UserSSId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UserSSId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserSSId",
                table: "Listings");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_UserSSes_SellerId",
                table: "Listings",
                column: "SellerId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserSSes_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_UserSSes_CreatorId",
                table: "Offers",
                column: "CreatorId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
