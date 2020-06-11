using Microsoft.EntityFrameworkCore.Migrations;

namespace Seller.Server.Data.Migrations
{
    public partial class Added_Title_Prop_Offers_and_Deals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Deals",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Deals");
        }
    }
}
