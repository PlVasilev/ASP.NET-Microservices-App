using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Server.Data.Migrations
{
    public partial class NameChanged_of_UserSeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_UserSSes_UserSSId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserSSes_UserSSId",
                table: "Messages");

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

            migrationBuilder.AddColumn<string>(
                name: "UserSellerId",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSellerId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSellerId",
                table: "Listings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserSellerId",
                table: "Offers",
                column: "UserSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserSellerId",
                table: "Messages",
                column: "UserSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UserSellerId",
                table: "Listings",
                column: "UserSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_UserSSes_UserSellerId",
                table: "Listings",
                column: "UserSellerId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserSSes_UserSellerId",
                table: "Messages",
                column: "UserSellerId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_UserSSes_UserSellerId",
                table: "Offers",
                column: "UserSellerId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_UserSSes_UserSellerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserSSes_UserSellerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserSSes_UserSellerId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_UserSellerId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserSellerId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Listings_UserSellerId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "UserSellerId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UserSellerId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserSellerId",
                table: "Listings");

            migrationBuilder.AddColumn<string>(
                name: "UserSSId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSSId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSSId",
                table: "Listings",
                type: "nvarchar(450)",
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
                name: "FK_Listings_UserSSes_UserSSId",
                table: "Listings",
                column: "UserSSId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserSSes_UserSSId",
                table: "Messages",
                column: "UserSSId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_UserSSes_UserSSId",
                table: "Offers",
                column: "UserSSId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
