using Microsoft.EntityFrameworkCore.Migrations;

namespace webapiefaction.Migrations
{
    public partial class studentcontextdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "id", "address", "age", "course", "studentname" },
                values: new object[] { 1, "sdssdfdf", 22, ".net", "agila" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "id", "address", "age", "course", "studentname" },
                values: new object[] { 2, "sdddsd asds", 22, "python", "tripu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
