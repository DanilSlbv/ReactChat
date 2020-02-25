using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactChat.DataAccessLayer.Migrations
{
    public partial class Feb2402 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdditionalSecurity",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PinCodeHash",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalSecurity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PinCodeHash",
                table: "AspNetUsers");
        }
    }
}
