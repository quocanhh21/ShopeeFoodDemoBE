using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeFood.DAL.EF.Migrations
{
    public partial class addImagePartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Partners");
        }
    }
}
