using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTeacher.Repo.Migrations
{
    public partial class addUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyMail",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyMail",
                table: "Customer",
                column: "CompanyMail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyTel",
                table: "Customer",
                column: "CompanyTel",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_CompanyMail",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CompanyTel",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyMail",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
