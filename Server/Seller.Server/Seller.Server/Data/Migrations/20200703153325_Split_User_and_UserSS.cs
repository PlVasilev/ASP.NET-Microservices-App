using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Server.Data.Migrations
{
    public partial class Split_User_and_UserSS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_AspNetUsers_BuyerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_AspNetUsers_SellerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_SellerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_CreatorId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserSSes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSSes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSSes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSSes_UserId",
                table: "UserSSes",
                column: "UserId",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_UserSSes_BuyerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_UserSSes_SellerId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_UserSSes_SellerId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserSSes_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_UserSSes_CreatorId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "UserSSes");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_AspNetUsers_BuyerId",
                table: "Deals",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_AspNetUsers_SellerId",
                table: "Deals",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_SellerId",
                table: "Listings",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_CreatorId",
                table: "Offers",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
