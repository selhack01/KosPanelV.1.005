using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTeacher.Repo.Migrations
{
    public partial class changeTelephone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CompanyTel",
                table: "Customer",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "CompanyTel",
                value: 55555555L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CompanyTel",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CompanyId",
                keyValue: 1,
                column: "CompanyTel",
                value: 55555555);
        }
    }
}
