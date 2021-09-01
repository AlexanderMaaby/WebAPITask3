using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCharactersWebAPI.Migrations
{
    public partial class AddDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCharacter",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacter", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Alias", "Gender", "Name", "PictureUrl" },
                values: new object[,]
                {
                    { 1, "Captain America", "Male", "Steve Rogers", "https://www.imdb.com/title/tt0458339/mediaviewer/rm2508504832/" },
                    { 2, "Iron man", "Male", "Tony Stark", "https://www.imdb.com/title/tt0371746/mediaviewer/rm286559232/" },
                    { 3, "Batman", "Male", "Bruce Wayne", "" }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "DC Comics, Inc. is an American comic book publisher and the flagship unit of DC Entertainment, a subsidiary of the Warner Bros. Global Brands and Experiences division of Warner Bros., which itself is a subsidiary of AT&T's WarnerMedia through its Studios & Networks division.", "DC" },
                    { 2, "Marvel Comics is the brand name and primary imprint of Marvel Worldwide Inc., formerly Marvel Publishing, Inc. and Marvel Comics Group, a publisher of American comic books and related media. In 2009, The Walt Disney Company acquired Marvel Entertainment, Marvel Worldwide's parent company.", "Marvel" },
                    { 3, "The Walt Disney Company, commonly known as Disney, is an American diversified multinational mass media and entertainment conglomerate headquartered at the Walt Disney Studios complex in Burbank, California.", "Disney" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "FranchiseId", "Genre", "PictureUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 4, 1, "Action", "", 2012, "Batman The Dark Knight", null },
                    { 1, 2, "Action", "https://www.imdb.com/title/tt0458339/mediaviewer/rm2438905344/", 2011, "Captain America", "https://www.imdb.com/video/vi2912787481/?ref_=tt_vi_i_1" },
                    { 2, 2, "Action", "https://www.imdb.com/title/tt0371746/mediaviewer/rm1544850432/", 2018, "Iron man", "https://www.imdb.com/video/vi447873305/?ref_=tt_vi_i_1" },
                    { 3, 2, "Action", "https://www.imdb.com/title/tt0848228/mediaviewer/rm3955117056/", 2012, "The Avengers", "https://www.imdb.com/video/vi1891149081/?ref_=tt_vi_i_1" }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 3, 4 },
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacter_MovieId",
                table: "MovieCharacter",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacter");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Franchise");
        }
    }
}
