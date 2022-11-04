using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    MinResponseLength = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    SourceUserID = table.Column<string>(type: "TEXT", nullable: true),
                    TargetUserID = table.Column<string>(type: "TEXT", nullable: true),
                    UsefulnessId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Response_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Response_Response_UsefulnessId",
                        column: x => x.UsefulnessId,
                        principalTable: "Response",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "ID", "MinResponseLength", "Text" },
                values: new object[] { 1, 0, "Question 0 from EF" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "ID", "MinResponseLength", "Text" },
                values: new object[] { 2, 0, "Question 1 from EF" });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "ID", "MinResponseLength", "Text" },
                values: new object[] { 3, 0, "Question 2 from EF" });

            migrationBuilder.CreateIndex(
                name: "IX_Response_QuestionID",
                table: "Response",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Response_UsefulnessId",
                table: "Response",
                column: "UsefulnessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
