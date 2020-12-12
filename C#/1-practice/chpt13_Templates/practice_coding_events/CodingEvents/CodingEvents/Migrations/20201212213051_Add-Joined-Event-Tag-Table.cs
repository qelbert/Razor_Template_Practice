using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEvents.Migrations
{
    public partial class AddJoinedEventTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTagsJoined",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    TagsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTagsJoined", x => new { x.EventId, x.TagId });
                    table.ForeignKey(
                        name: "FK_EventTagsJoined_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTagsJoined_EventTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "EventTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTagsJoined_TagsId",
                table: "EventTagsJoined",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTagsJoined");
        }
    }
}
