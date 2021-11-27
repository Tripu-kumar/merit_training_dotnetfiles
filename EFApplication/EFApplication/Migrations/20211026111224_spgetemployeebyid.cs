using Microsoft.EntityFrameworkCore.Migrations;

namespace EFApplication.Migrations
{
    public partial class spgetemployeebyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create procedure spgetemployeebyid
                               @id int
                               as
                               begin
                                 select * from EmployeeMerit
                                  where employeeID=@id
                                    end";
            migrationBuilder.Sql(procedure);



            /* migrationBuilder.CreateTable(
                 name: "EmployeeMerit",
                 columns: table => new
                 {
                     employeeID = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     employeename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                     employee_sal = table.Column<int>(type: "int", nullable: false),
                     employee_dept = table.Column<string>(type: "nvarchar(max)", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_EmployeeMerit", x => x.employeeID);
                 });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "EmployeeMerit");*/
            string procedure = @"Drop procedure spgetemployeebyid";
            migrationBuilder.Sql(procedure);
        }
    }
}
