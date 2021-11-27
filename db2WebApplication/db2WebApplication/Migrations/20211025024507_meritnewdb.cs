using Microsoft.EntityFrameworkCore.Migrations;

namespace db2WebApplication.Migrations
{
    public partial class meritnewdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    bookid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bookid1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.bookid);
                    table.ForeignKey(
                        name: "FK_books_books_bookid1",
                        column: x => x.bookid1,
                        principalTable: "books",
                        principalColumn: "bookid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    authorid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pubyear = table.Column<int>(type: "int", nullable: false),
                    Bookid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.authorid);
                    table.ForeignKey(
                        name: "FK_authors_books_Bookid",
                        column: x => x.Bookid,
                        principalTable: "books",
                        principalColumn: "bookid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "bookid", "bookid1", "bookname" },
                values: new object[] { 1, null, "asdsfsd" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "bookid", "bookid1", "bookname" },
                values: new object[] { 2, null, "hjkhjh" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "bookid", "bookid1", "bookname" },
                values: new object[] { 3, null, "jhuyuu" });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "authorid", "Bookid", "authorname", "pubyear" },
                values: new object[,]
                {
                    { 11, 1, "aaaa", 2018 },
                    { 12, 2, "bbb", 2020 },
                    { 14, 2, "dfdfd", 2018 },
                    { 13, 3, "cccc", 2021 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_authors_Bookid",
                table: "authors",
                column: "Bookid");

            migrationBuilder.CreateIndex(
                name: "IX_books_bookid1",
                table: "books",
                column: "bookid1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
