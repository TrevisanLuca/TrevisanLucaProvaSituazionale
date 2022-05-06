using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrevisanLucaProvaSituazionale.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    MaxSpectators = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaHalls_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaHalls_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaHallId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spectators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    CinemaHallId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spectators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spectators_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Spectators_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cinema Quattro Stagioni" },
                    { 2, "Cinema Dante" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Author", "Genre", "Length", "Producer", "Title" },
                values: new object[,]
                {
                    { 1, "Peter Jackson", "Fantasy", 180, "New Line Cinema", "Lord of the Rings" },
                    { 2, "Gore Verbinski", "Horror", 90, "Hiroshi Takahashi", "The Ring" }
                });

            migrationBuilder.InsertData(
                table: "CinemaHalls",
                columns: new[] { "Id", "CinemaId", "FilmId", "MaxSpectators", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, 50, "Primavera" },
                    { 2, 1, 2, 60, "Estate" },
                    { 3, 1, 1, 20, "Autunno" },
                    { 4, 1, 2, 15, "Inverno" },
                    { 5, 2, 1, 100, "Inferno" },
                    { 6, 2, 2, 150, "Purgatorio" },
                    { 7, 2, 1, 10, "Paradiso" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CinemaHallId", "Position", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 10m },
                    { 2, 1, 2, 10m },
                    { 3, 6, 1, 10m },
                    { 4, 3, 1, 10m }
                });

            migrationBuilder.InsertData(
                table: "Spectators",
                columns: new[] { "Id", "CinemaHallId", "DateOfBirth", "Name", "Surname", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1950, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario", "Bianchi", 1 },
                    { 2, 1, new DateTime(1988, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giuseppe", "Rossi", 2 },
                    { 3, 6, new DateTime(1998, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miriam", "Verdi", 3 },
                    { 4, 3, new DateTime(2007, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giovanna", "Neri", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_CinemaId",
                table: "CinemaHalls",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_FilmId",
                table: "CinemaHalls",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Spectators_CinemaHallId",
                table: "Spectators",
                column: "CinemaHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Spectators_TicketId",
                table: "Spectators",
                column: "TicketId",
                unique: true,
                filter: "[TicketId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaHallId",
                table: "Tickets",
                column: "CinemaHallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spectators");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "CinemaHalls");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
