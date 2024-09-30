using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTask.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dep_loc",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "int", nullable: false),
                    Dloaction = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    departmentDNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dep_loc", x => new { x.Dnumber, x.Dloaction });
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGRSSN = table.Column<int>(type: "int", nullable: true),
                    MGRStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DNum);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ssn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    supeerSSN = table.Column<int>(type: "int", nullable: true),
                    DNO = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ssn);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DNO",
                        column: x => x.DNO,
                        principalTable: "Departments",
                        principalColumn: "DNum");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_supeerSSN",
                        column: x => x.supeerSSN,
                        principalTable: "Employees",
                        principalColumn: "ssn");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Pnum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Pnum);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "Departments",
                        principalColumn: "DNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    dependentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    essn = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    realation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.dependentName);
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_essn",
                        column: x => x.essn,
                        principalTable: "Employees",
                        principalColumn: "ssn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WOn",
                columns: table => new
                {
                    Essn = table.Column<int>(type: "int", nullable: false),
                    pno = table.Column<int>(type: "int", nullable: false),
                    hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WOn", x => new { x.Essn, x.pno });
                    table.ForeignKey(
                        name: "FK_WOn_Employees_Essn",
                        column: x => x.Essn,
                        principalTable: "Employees",
                        principalColumn: "ssn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WOn_Projects_pno",
                        column: x => x.pno,
                        principalTable: "Projects",
                        principalColumn: "Pnum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dep_loc_departmentDNum",
                table: "dep_loc",
                column: "departmentDNum");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MGRSSN",
                table: "Departments",
                column: "MGRSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_essn",
                table: "Dependents",
                column: "essn");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DNO",
                table: "Employees",
                column: "DNO");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_supeerSSN",
                table: "Employees",
                column: "supeerSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Dnum",
                table: "Projects",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_WOn_pno",
                table: "WOn",
                column: "pno");

            migrationBuilder.AddForeignKey(
                name: "FK_dep_loc_Departments_departmentDNum",
                table: "dep_loc",
                column: "departmentDNum",
                principalTable: "Departments",
                principalColumn: "DNum");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_MGRSSN",
                table: "Departments",
                column: "MGRSSN",
                principalTable: "Employees",
                principalColumn: "ssn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DNO",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "dep_loc");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "WOn");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
