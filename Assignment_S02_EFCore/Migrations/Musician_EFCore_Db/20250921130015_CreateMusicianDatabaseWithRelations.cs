using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_S02_EFCore.Migrations.Musician_EFCore_Db
{
    /// <inheritdoc />
    public partial class CreateMusicianDatabaseWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Mus_Instruments",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mus_Instruments", x => new { x.MusicianId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_Mus_Instruments_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mus_Instruments_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mus_Songs",
                columns: table => new
                {
                    MusicianId = table.Column<int>(type: "int", nullable: false),
                    SongTitle = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mus_Songs", x => new { x.MusicianId, x.SongTitle });
                    table.ForeignKey(
                        name: "FK_Mus_Songs_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mus_Songs_Songs_SongTitle",
                        column: x => x.SongTitle,
                        principalTable: "Songs",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Album_Songs",
                columns: table => new
                {
                    SongTitle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album_Songs", x => new { x.SongTitle, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_Album_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Album_Songs_Songs_SongTitle",
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

            migrationBuilder.CreateIndex(
                name: "IX_Album_Songs_AlbumId",
                table: "Album_Songs",
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
                name: "IX_Mus_Instruments_InstrumentId",
                table: "Mus_Instruments",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Mus_Songs_SongTitle",
                table: "Mus_Songs",
                column: "SongTitle");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SalesOffices_AssignedOfficeID",
                table: "Employees",
                column: "AssignedOfficeID",
                principalTable: "SalesOffices",
                principalColumn: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SalesOffices_AssignedOfficeID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Album_Songs");

            migrationBuilder.DropTable(
                name: "Mus_Instruments");

            migrationBuilder.DropTable(
                name: "Mus_Songs");

            migrationBuilder.DropTable(
                name: "Prop_Owner");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "SalesOffices");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
