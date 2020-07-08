using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Listings.Migrations
{
    public partial class AddedIsAcceptedPropToListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Deals",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Deals");
        }
    }
}
