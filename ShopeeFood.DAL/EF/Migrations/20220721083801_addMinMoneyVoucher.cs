using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopeeFood.DAL.EF.Migrations
{
    public partial class addMinMoneyVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MinMoney",
                table: "Vouchers",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinMoney",
                table: "Vouchers");
        }
    }
}
