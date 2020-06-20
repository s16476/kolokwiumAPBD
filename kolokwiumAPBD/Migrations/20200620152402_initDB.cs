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
                    table.PrimaryKey("PK_Artists", x => x.IdArtist);
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
                    table.PrimaryKey("PK_Events", x => x.IdEvent);
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
                    table.PrimaryKey("PK_Organisers", x => x.IdOrganiser);
                });

            migrationBuilder.CreateTable(
                name: "Artist_Events",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdArtist = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ArtistIdArtist = table.Column<int>(nullable: true),
                    EventIdEvent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Events", x => new { x.IdArtist, x.IdEvent });
                    table.ForeignKey(
                        name: "FK_Artist_Events_Artists_ArtistIdArtist",
                        column: x => x.ArtistIdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artist_Events_Events_EventIdEvent",
                        column: x => x.EventIdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event_Organisers",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false),
                    IdOrganiser = table.Column<int>(nullable: false),
                    EventIdEvent = table.Column<int>(nullable: true),
                    OrganiserIdOrganiser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Organisers", x => new { x.IdEvent, x.IdOrganiser });
                    table.ForeignKey(
                        name: "FK_Event_Organisers_Events_EventIdEvent",
                        column: x => x.EventIdEvent,
                        principalTable: "Events",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_Organisers_Organisers_OrganiserIdOrganiser",
                        column: x => x.OrganiserIdOrganiser,
                        principalTable: "Organisers",
                        principalColumn: "IdOrganiser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Artist_Events",
                columns: new[] { "IdArtist", "IdEvent", "ArtistIdArtist", "DateTime", "EventIdEvent" },
                values: new object[,]
                {
                    { 4, 3, null, new DateTime(2020, 8, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 3, null, new DateTime(2020, 8, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 2, null, new DateTime(2020, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, null, new DateTime(2020, 7, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 1, 1, null, new DateTime(2020, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 1, null, new DateTime(2020, 7, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[,]
                {
                    { 1, "Slash" },
                    { 3, "Bruno" },
                    { 2, "Axel" },
                    { 4, "Mick" }
                });

            migrationBuilder.InsertData(
                table: "Event_Organisers",
                columns: new[] { "IdEvent", "IdOrganiser", "EventIdEvent", "OrganiserIdOrganiser" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 1, null, null }
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

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Events_ArtistIdArtist",
                table: "Artist_Events",
                column: "ArtistIdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Events_EventIdEvent",
                table: "Artist_Events",
                column: "EventIdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Organisers_EventIdEvent",
                table: "Event_Organisers",
                column: "EventIdEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Organisers_OrganiserIdOrganiser",
                table: "Event_Organisers",
                column: "OrganiserIdOrganiser");
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
