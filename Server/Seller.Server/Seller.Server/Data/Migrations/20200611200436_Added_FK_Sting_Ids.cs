using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Server.Data.Migrations
{
    public partial class Added_FK_Sting_Ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Deals_DealId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_DealId",
                table: "Listings");

            migrationBuilder.AlterColumn<string>(
                name: "DealId",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListingId",
                table: "Deals",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ListingId",
                table: "Deals",
                column: "ListingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Listings_ListingId",
                table: "Deals",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Listings_ListingId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_ListingId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Deals");

            migrationBuilder.AlterColumn<string>(
                name: "DealId",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_DealId",
                table: "Listings",
                column: "DealId",
                unique: true,
                filter: "[DealId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Deals_DealId",
                table: "Listings",
                column: "DealId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
