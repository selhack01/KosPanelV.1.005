using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTeacher.Repo.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyTel = table.Column<int>(type: "int", nullable: false),
                    CompanySector = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CompanyId);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CompanyId", "CompanyMail", "CompanyName", "CompanySector", "CompanyTel", "CompanyWeb" },
                values: new object[] { 1, "company@example.com", "Company", "Software", 55555555, "www.company.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
