using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Listings.Migrations
{
    public partial class InitalListingsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSellers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    DealId = table.Column<string>(nullable: true),
                    SellerId = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_UserSellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "UserSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SenderId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserSellerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_UserSellers_UserSellerId",
                        column: x => x.UserSellerId,
                        principalTable: "UserSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ListingId = table.Column<string>(nullable: false),
                    SellerId = table.Column<string>(nullable: false),
                    BuyerId = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deals_UserSellers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "UserSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deals_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deals_UserSellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "UserSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ListingId = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserSellerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_UserSellers_UserSellerId",
                        column: x => x.UserSellerId,
                        principalTable: "UserSellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deals_BuyerId",
                table: "Deals",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ListingId",
                table: "Deals",
                column: "ListingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_SellerId",
                table: "Deals",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_SellerId",
                table: "Listings",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserSellerId",
                table: "Messages",
                column: "UserSellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ListingId",
                table: "Offers",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserSellerId",
                table: "Offers",
                column: "UserSellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "UserSellers");
        }
    }
}
