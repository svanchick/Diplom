using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kurs_v3.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Displays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Displays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfPosition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assemblies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateId = table.Column<int>(type: "int", nullable: false),
                    DialId = table.Column<int>(type: "int", nullable: false),
                    DisplayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assemblies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assemblies_Dials_DialId",
                        column: x => x.DialId,
                        principalTable: "Dials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assemblies_Displays_DisplayId",
                        column: x => x.DisplayId,
                        principalTable: "Displays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assemblies_Plates_PlateId",
                        column: x => x.PlateId,
                        principalTable: "Plates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Positions_Position",
                        column: x => x.Position,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dials",
                columns: new[] { "Id", "Cost", "Description", "Name", "SerialNumber" },
                values: new object[] { 1, 0, "", "None", "-" });

            migrationBuilder.InsertData(
                table: "Displays",
                columns: new[] { "Id", "Cost", "Description", "Name", "SerialNumber" },
                values: new object[] { 1, 0, "", "None", "-" });

            migrationBuilder.InsertData(
                table: "Plates",
                columns: new[] { "Id", "Cost", "Description", "Name", "SerialNumber" },
                values: new object[] { 1, 0, "", "None", "-" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "NameOfPosition" },
                values: new object[,]
                {
                    { 1, "Админ" },
                    { 2, "Секретарь" },
                    { 3, "Конструктор" },
                    { 4, "Сборщик" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Patronymic", "Position", "Surname" },
                values: new object[] { 1, "Admin", "Admin", "Admin", "", 1, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Assemblies_DialId",
                table: "Assemblies",
                column: "DialId");

            migrationBuilder.CreateIndex(
                name: "IX_Assemblies_DisplayId",
                table: "Assemblies",
                column: "DisplayId");

            migrationBuilder.CreateIndex(
                name: "IX_Assemblies_PlateId",
                table: "Assemblies",
                column: "PlateId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Position",
                table: "Users",
                column: "Position");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assemblies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dials");

            migrationBuilder.DropTable(
                name: "Displays");

            migrationBuilder.DropTable(
                name: "Plates");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
