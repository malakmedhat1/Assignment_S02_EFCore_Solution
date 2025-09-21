using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_S02_EFCore.Migrations.Sales_EFCore_Db
{
    /// <inheritdoc />
    public partial class CreateSalesDatabaseWithRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Prop_Owners",
                columns: table => new
                {
                    OwnId = table.Column<int>(type: "int", nullable: false),
                    PropId = table.Column<int>(type: "int", nullable: false),
                    percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prop_Owners", x => new { x.OwnId, x.PropId });
                    table.ForeignKey(
                        name: "FK_Prop_Owners_Owners_OwnId",
                        column: x => x.OwnId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prop_Owners_Properties_PropId",
                        column: x => x.PropId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AssignedOfficeID",
                table: "Employees",
                column: "AssignedOfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_Owners_PropId",
                table: "Prop_Owners",
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
                name: "Prop_Owners");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "SalesOffices");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
