using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transformatek_MP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Famillyname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Famillyname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Point_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Lat = table.Column<float>(type: "REAL", nullable: false),
                    Lang = table.Column<float>(type: "REAL", nullable: false),
                    Affectation_ID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Point_ID);
                });

            migrationBuilder.CreateTable(
                name: "Resultes",
                columns: table => new
                {
                    Result_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Mesuretype = table.Column<string>(type: "TEXT", nullable: false),
                    Values = table.Column<string>(type: "TEXT", nullable: false),
                    AgentId = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultes", x => x.Result_Id);
                    table.ForeignKey(
                        name: "FK_Resultes_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Affectation",
                columns: table => new
                {
                    Affectation_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Admin_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    AgentId = table.Column<string>(type: "TEXT", nullable: true),
                    Point_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Consigner_ID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affectation", x => x.Affectation_ID);
                    table.ForeignKey(
                        name: "FK_Affectation_Admins_Admin_ID",
                        column: x => x.Admin_ID,
                        principalTable: "Admins",
                        principalColumn: "Admin_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Affectation_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Affectation_Point_Affectation_ID",
                        column: x => x.Affectation_ID,
                        principalTable: "Point",
                        principalColumn: "Point_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Affectation_Point_Point_ID",
                        column: x => x.Point_ID,
                        principalTable: "Point",
                        principalColumn: "Point_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consigner",
                columns: table => new
                {
                    Consigner_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Type_mesure = table.Column<string>(type: "TEXT", nullable: false),
                    Nb_Repetations = table.Column<int>(type: "INTEGER", nullable: false),
                    Affectation_ID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consigner", x => x.Consigner_ID);
                    table.ForeignKey(
                        name: "FK_Consigner_Affectation_Affectation_ID",
                        column: x => x.Affectation_ID,
                        principalTable: "Affectation",
                        principalColumn: "Affectation_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_Admin_ID",
                table: "Affectation",
                column: "Admin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_AgentId",
                table: "Affectation",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_Consigner_ID",
                table: "Affectation",
                column: "Consigner_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_Point_ID",
                table: "Affectation",
                column: "Point_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consigner_Affectation_ID",
                table: "Consigner",
                column: "Affectation_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resultes_AgentId",
                table: "Resultes",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Affectation_Consigner_Consigner_ID",
                table: "Affectation",
                column: "Consigner_ID",
                principalTable: "Consigner",
                principalColumn: "Consigner_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affectation_Admins_Admin_ID",
                table: "Affectation");

            migrationBuilder.DropForeignKey(
                name: "FK_Affectation_Agent_AgentId",
                table: "Affectation");

            migrationBuilder.DropForeignKey(
                name: "FK_Affectation_Consigner_Consigner_ID",
                table: "Affectation");

            migrationBuilder.DropTable(
                name: "Resultes");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Consigner");

            migrationBuilder.DropTable(
                name: "Affectation");

            migrationBuilder.DropTable(
                name: "Point");
        }
    }
}
