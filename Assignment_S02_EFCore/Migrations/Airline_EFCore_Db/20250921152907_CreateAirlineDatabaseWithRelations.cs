using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_S02_EFCore.Migrations.Airline_EFCore_Db
{
    /// <inheritdoc />
    public partial class CreateAirlineDatabaseWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Airline");

            migrationBuilder.CreateTable(
                name: "AirLines",
                schema: "Airline",
                columns: table => new
                {
                    AirLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.AirLineId);
                });

            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ph_Number = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                schema: "Airline",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "AirCrafts",
                schema: "Airline",
                columns: table => new
                {
                    AirCraftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajPilot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Assisstant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Host1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Host2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    AirLineOwningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirCrafts", x => x.AirCraftId);
                    table.ForeignKey(
                        name: "FK_AirCrafts_AirLines_AirLineOwningId",
                        column: x => x.AirLineOwningId,
                        principalSchema: "Airline",
                        principalTable: "AirLines",
                        principalColumn: "AirLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirlinePhones",
                columns: table => new
                {
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlinePhones", x => new { x.AirLineId, x.PhoneNumber });
                    table.ForeignKey(
                        name: "FK_AirlinePhones_AirLines_AirLineId",
                        column: x => x.AirLineId,
                        principalSchema: "Airline",
                        principalTable: "AirLines",
                        principalColumn: "AirLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Airline",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hiredate = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeeWorkingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AirLines_EmployeeWorkingId",
                        column: x => x.EmployeeWorkingId,
                        principalSchema: "Airline",
                        principalTable: "AirLines",
                        principalColumn: "AirLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Airline",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionsRecordedID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_AirLines_TransactionsRecordedID",
                        column: x => x.TransactionsRecordedID,
                        principalSchema: "Airline",
                        principalTable: "AirLines",
                        principalColumn: "AirLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MusicianProductionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Musicians_MusicianProductionId",
                        column: x => x.MusicianProductionId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mus_Instrument",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mus_Instrument", x => new { x.MusicianId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_Mus_Instrument_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mus_Instrument_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mus_Song",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "int", nullable: false),
                    SongTitle = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mus_Song", x => new { x.MusicianId, x.SongTitle });
                    table.ForeignKey(
                        name: "FK_Mus_Song_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mus_Song_Songs_SongTitle",
                        column: x => x.SongTitle,
                        principalTable: "Songs",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AircraftRoutes",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    Depature = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumOfPassengers = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Arrival = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftRoutes", x => new { x.AircraftId, x.RouteId, x.Depature });
                    table.ForeignKey(
                        name: "FK_AircraftRoutes_AirCrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalSchema: "Airline",
                        principalTable: "AirCrafts",
                        principalColumn: "AirCraftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AircraftRoutes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalSchema: "Airline",
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeQualifications",
                columns: table => new
                {
                    QualificationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeQualifications", x => new { x.EmployeeId, x.QualificationName });
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Airline",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Album_Song",
                columns: table => new
                {
                    SongTitle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album_Song", x => new { x.SongTitle, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_Album_Song_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Album_Song_Songs_SongTitle",
                        column: x => x.SongTitle,
                        principalTable: "Songs",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedOfficeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOffices",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOffices", x => x.Number);
                    table.ForeignKey(
                        name: "FK_SalesOffices_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListedOfficeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_SalesOffices_ListedOfficeID",
                        column: x => x.ListedOfficeID,
                        principalTable: "SalesOffices",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prop_Owner",
                columns: table => new
                {
                    OwnId = table.Column<int>(type: "int", nullable: false),
                    PropId = table.Column<int>(type: "int", nullable: false),
                    percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prop_Owner", x => new { x.OwnId, x.PropId });
                    table.ForeignKey(
                        name: "FK_Prop_Owner_Owners_OwnId",
                        column: x => x.OwnId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prop_Owner_Properties_PropId",
                        column: x => x.PropId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NurseDrugPatient",
                columns: table => new
                {
                    NurseID = table.Column<int>(type: "int", nullable: false),
                    DrugCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseDrugPatient", x => new { x.NurseID, x.DrugCode, x.PatientId });
                    table.ForeignKey(
                        name: "FK_NurseDrugPatient_Drugs_DrugCode",
                        column: x => x.DrugCode,
                        principalTable: "Drugs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NerseServedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wards_Nurses_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostWardId = table.Column<int>(type: "int", nullable: true),
                    AssignedConsultantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Consultants_AssignedConsultantId",
                        column: x => x.AssignedConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Wards_HostWardId",
                        column: x => x.HostWardId,
                        principalTable: "Wards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientConsultant",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientConsultant", x => new { x.PatientId, x.ConsultantId });
                    table.ForeignKey(
                        name: "FK_PatientConsultant_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientConsultant_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftRoutes_RouteId",
                table: "AircraftRoutes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_AirCrafts_AirLineOwningId",
                schema: "Airline",
                table: "AirCrafts",
                column: "AirLineOwningId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_Song_AlbumId",
                table: "Album_Song",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MusicianProductionId",
                table: "Albums",
                column: "MusicianProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AssignedOfficeID",
                table: "Employees",
                column: "AssignedOfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeWorkingId",
                schema: "Airline",
                table: "Employees",
                column: "EmployeeWorkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Mus_Instrument_InstrumentId",
                table: "Mus_Instrument",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Mus_Song_SongTitle",
                table: "Mus_Song",
                column: "SongTitle");

            migrationBuilder.CreateIndex(
                name: "IX_NurseDrugPatient_DrugCode",
                table: "NurseDrugPatient",
                column: "DrugCode");

            migrationBuilder.CreateIndex(
                name: "IX_NurseDrugPatient_PatientId",
                table: "NurseDrugPatient",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_NerseServedId",
                table: "Nurses",
                column: "NerseServedId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientConsultant_ConsultantId",
                table: "PatientConsultant",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AssignedConsultantId",
                table: "Patients",
                column: "AssignedConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HostWardId",
                table: "Patients",
                column: "HostWardId");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_Owner_PropId",
                table: "Prop_Owner",
                column: "PropId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ListedOfficeID",
                table: "Properties",
                column: "ListedOfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOffices_ManagerId",
                table: "SalesOffices",
                column: "ManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionsRecordedID",
                schema: "Airline",
                table: "Transactions",
                column: "TransactionsRecordedID");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_SupervisorId",
                table: "Wards",
                column: "SupervisorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SalesOffices_AssignedOfficeID",
                table: "Employees",
                column: "AssignedOfficeID",
                principalTable: "SalesOffices",
                principalColumn: "Number");

            migrationBuilder.AddForeignKey(
                name: "FK_NurseDrugPatient_Nurses_NurseID",
                table: "NurseDrugPatient",
                column: "NurseID",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NurseDrugPatient_Patients_PatientId",
                table: "NurseDrugPatient",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Wards_NerseServedId",
                table: "Nurses",
                column: "NerseServedId",
                principalTable: "Wards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SalesOffices_AssignedOfficeID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Nurses_SupervisorId",
                table: "Wards");

            migrationBuilder.DropTable(
                name: "AircraftRoutes");

            migrationBuilder.DropTable(
                name: "AirlinePhones");

            migrationBuilder.DropTable(
                name: "Album_Song");

            migrationBuilder.DropTable(
                name: "EmployeeQualifications");

            migrationBuilder.DropTable(
                name: "Mus_Instrument");

            migrationBuilder.DropTable(
                name: "Mus_Song");

            migrationBuilder.DropTable(
                name: "NurseDrugPatient");

            migrationBuilder.DropTable(
                name: "PatientConsultant");

            migrationBuilder.DropTable(
                name: "Prop_Owner");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Airline");

            migrationBuilder.DropTable(
                name: "AirCrafts",
                schema: "Airline");

            migrationBuilder.DropTable(
                name: "Routes",
                schema: "Airline");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Airline");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "AirLines",
                schema: "Airline");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "SalesOffices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Wards");
        }
    }
}
