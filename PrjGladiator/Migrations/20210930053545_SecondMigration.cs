using Microsoft.EntityFrameworkCore.Migrations;

namespace PrjGladiator.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Report_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marks = table.Column<int>(type: "int", nullable: false),
                    QuestionSetRef_Id = table.Column<int>(type: "int", nullable: false),
                    UserRef_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Report_Id);
                    table.ForeignKey(
                        name: "FK_Reports_QuestionSets_QuestionSetRef_Id",
                        column: x => x.QuestionSetRef_Id,
                        principalTable: "QuestionSets",
                        principalColumn: "QuestionSet_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserRef_Id",
                        column: x => x.UserRef_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_QuestionSetRef_Id",
                table: "Reports",
                column: "QuestionSetRef_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserRef_Id",
                table: "Reports",
                column: "UserRef_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
