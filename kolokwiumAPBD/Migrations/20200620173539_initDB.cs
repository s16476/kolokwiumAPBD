using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwiumAPBD.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    IdArtist = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Artist_pk", x => x.IdArtist);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Event_pk", x => x.IdEvent);
                });

            migrationBuilder.CreateTable(
                name: "Organisers",
                columns: table => new
                {
                    IdOrganiser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Organiser_pk", x => x.IdOrganiser);
                });

            migrationBuilder.CreateTable(
                name: "Artist_Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdArtist = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Artist_Event_pk", x => new { x.IdArtist, x.IdEvent });
                    table.ForeignKey(
                        name: "FK_Artist_Events_Artists_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artist_Events_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Organisers",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdOrganiser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Organisers", x => new { x.IdEvent, x.IdOrganiser });
                    table.ForeignKey(
                        name: "FK_Event_Organisers_Events_IdEvent",
                        column: x => x.IdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Organisers_Organisers_IdOrganiser",
                        column: x => x.IdOrganiser,
                        principalTable: "Organisers",
                        principalColumn: "IdOrganiser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[,]
                {
                    { 1, "Slash" },
                    { 2, "Axel" },
                    { 3, "Bruno" },
                    { 4, "Mick" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 11, 23, 0, 0, 0, DateTimeKind.Unspecified), "Wieczor muzyczny WWa", new DateTime(2020, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2020, 7, 23, 23, 30, 0, 0, DateTimeKind.Unspecified), "Go Rock", new DateTime(2020, 7, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2020, 8, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), "Warsaw Festival", new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Organisers",
                columns: new[] { "IdOrganiser", "Name" },
                values: new object[,]
                {
                    { 1, "Evenea" },
                    { 2, "GoLIve" }
                });

            migrationBuilder.InsertData(
                table: "Artist_Events",
                columns: new[] { "IdArtist", "IdEvent", "DateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2020, 7, 11, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2020, 7, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2020, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2020, 8, 5, 19, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Event_Organisers",
                columns: new[] { "IdEvent", "IdOrganiser" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Events_IdEvent",
                table: "Artist_Events",
                column: "IdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Organisers_IdOrganiser",
                table: "Event_Organisers",
                column: "IdOrganiser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist_Events");

            migrationBuilder.DropTable(
                name: "Event_Organisers");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Organisers");
        }
    }
}
