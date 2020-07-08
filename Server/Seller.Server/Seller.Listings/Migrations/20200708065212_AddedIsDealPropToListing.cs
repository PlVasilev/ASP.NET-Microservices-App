using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Listings.Migrations
{
    public partial class AddedIsDealPropToListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Deals");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeal",
                table: "Listings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeal",
                table: "Listings");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Deals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
