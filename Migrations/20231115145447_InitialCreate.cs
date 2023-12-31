﻿using System;
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
                    Name_Admin = table.Column<string>(type: "TEXT", nullable: false),
                    Famillyname_Admin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id_Agent = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name_Agent = table.Column<string>(type: "TEXT", nullable: false),
                    Famillyname_Agent = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.Id_Agent);
                });

            migrationBuilder.CreateTable(
                name: "Affectation",
                columns: table => new
                {
                    Affectation_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Admin_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    AgentId_Agent = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Affectation_Agent_AgentId_Agent",
                        column: x => x.AgentId_Agent,
                        principalTable: "Agent",
                        principalColumn: "Id_Agent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consigner",
                columns: table => new
                {
                    Consigner_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Type_mesure = table.Column<string>(type: "TEXT", nullable: false),
                    Nb_Repetations = table.Column<int>(type: "INTEGER", nullable: false),
                    Affectation_ID = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Point_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Lat = table.Column<float>(type: "REAL", nullable: false),
                    Lang = table.Column<float>(type: "REAL", nullable: false),
                    Affectation_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Point_ID);
                    table.ForeignKey(
                        name: "FK_Point_Affectation_Affectation_ID",
                        column: x => x.Affectation_ID,
                        principalTable: "Affectation",
                        principalColumn: "Affectation_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultes",
                columns: table => new
                {
                    Result_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mesuretype = table.Column<string>(type: "TEXT", nullable: false),
                    Values = table.Column<string>(type: "TEXT", nullable: false),
                    AgentId_Agent = table.Column<int>(type: "INTEGER", nullable: false),
                    Affectation_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultes", x => x.Result_Id);
                    table.ForeignKey(
                        name: "FK_Resultes_Affectation_Affectation_ID",
                        column: x => x.Affectation_ID,
                        principalTable: "Affectation",
                        principalColumn: "Affectation_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultes_Agent_AgentId_Agent",
                        column: x => x.AgentId_Agent,
                        principalTable: "Agent",
                        principalColumn: "Id_Agent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_Admin_ID",
                table: "Affectation",
                column: "Admin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_AgentId_Agent",
                table: "Affectation",
                column: "AgentId_Agent");

            migrationBuilder.CreateIndex(
                name: "IX_Consigner_Affectation_ID",
                table: "Consigner",
                column: "Affectation_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Point_Affectation_ID",
                table: "Point",
                column: "Affectation_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resultes_Affectation_ID",
                table: "Resultes",
                column: "Affectation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Resultes_AgentId_Agent",
                table: "Resultes",
                column: "AgentId_Agent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consigner");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Resultes");

            migrationBuilder.DropTable(
                name: "Affectation");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Agent");
        }
    }
}
