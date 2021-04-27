using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolio.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyPortfolioInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LasttName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyProjectsLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    School2Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TecnicalCompitences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExprience1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExprience2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExprience3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExprience4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExprience5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    References = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPortfolioInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyPortfolioInfo");
        }
    }
}
