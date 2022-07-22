using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeFood.DAL.EF.Migrations
{
    public partial class addCodeVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Vouchers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Vouchers");
        }
    }
}
