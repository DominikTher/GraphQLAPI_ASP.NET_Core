using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    NumberOfRooms = table.Column<int>(nullable: true),
                    PricePerNight = table.Column<float>(nullable: true),
                    HotelType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: false),
                    FancyHotelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelReviews_HotelEntity_FancyHotelId",
                        column: x => x.FancyHotelId,
                        principalTable: "HotelEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelReviews_HotelEntity_HotelId",
                        column: x => x.HotelId,
                        principalTable: "HotelEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelReviews_FancyHotelId",
                table: "HotelReviews",
                column: "FancyHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReviews_HotelId",
                table: "HotelReviews",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelReviews");

            migrationBuilder.DropTable(
                name: "HotelEntity");
        }
    }
}
