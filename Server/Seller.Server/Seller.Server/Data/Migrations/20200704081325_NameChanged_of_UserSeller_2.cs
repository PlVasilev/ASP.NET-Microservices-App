using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Server.Data.Migrations
{
    public partial class NameChanged_of_UserSeller_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_UserSSes_BuyerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_UserSSes_SellerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_UserSSes_UserSellerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserSSes_UserSellerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserSSes_UserSellerId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSSes_AspNetUsers_UserId",
                table: "UserSSes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSSes",
                table: "UserSSes");

            migrationBuilder.RenameTable(
                name: "UserSSes",
                newName: "UserSellers");

            migrationBuilder.RenameIndex(
                name: "IX_UserSSes_UserId",
                table: "UserSellers",
                newName: "IX_UserSellers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSellers",
                table: "UserSellers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_UserSellers_BuyerId",
                table: "Deals",
                column: "BuyerId",
                principalTable: "UserSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_UserSellers_SellerId",
                table: "Deals",
                column: "SellerId",
                principalTable: "UserSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_UserSellers_UserSellerId",
                table: "Listings",
                column: "UserSellerId",
                principalTable: "UserSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserSellers_UserSellerId",
                table: "Messages",
                column: "UserSellerId",
                principalTable: "UserSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_UserSellers_UserSellerId",
                table: "Offers",
                column: "UserSellerId",
                principalTable: "UserSellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSellers_AspNetUsers_UserId",
                table: "UserSellers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_UserSellers_BuyerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_UserSellers_SellerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_UserSellers_UserSellerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserSellers_UserSellerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserSellers_UserSellerId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSellers_AspNetUsers_UserId",
                table: "UserSellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSellers",
                table: "UserSellers");

            migrationBuilder.RenameTable(
                name: "UserSellers",
                newName: "UserSSes");

            migrationBuilder.RenameIndex(
                name: "IX_UserSellers_UserId",
                table: "UserSSes",
                newName: "IX_UserSSes_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSSes",
                table: "UserSSes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_UserSSes_BuyerId",
                table: "Deals",
                column: "BuyerId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_UserSSes_SellerId",
                table: "Deals",
                column: "SellerId",
                principalTable: "UserSSes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserSSes_AspNetUsers_UserId",
                table: "UserSSes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
