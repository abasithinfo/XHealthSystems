using Microsoft.EntityFrameworkCore.Migrations;

namespace XHealthHospitalSystems.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(250)", nullable: false),
                    RegNo = table.Column<string>(type: "varchar(250)", nullable: false),
                    Qualification = table.Column<string>(type: "varchar(500)", nullable: false),
                    VDate = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Note = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(250)", nullable: false),
                    Address = table.Column<string>(type: "varchar(500)", nullable: false),
                    EmgrCont = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    BloodType = table.Column<string>(type: "varchar(250)", nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TelNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symtoms = table.Column<string>(type: "varchar(500)", nullable: false),
                    Diagnosiss = table.Column<string>(type: "varchar(500)", nullable: false),
                    MedsPres = table.Column<string>(type: "varchar(500)", nullable: false),
                    TestsPres = table.Column<string>(type: "varchar(500)", nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.DiagnosisId);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
