using Microsoft.EntityFrameworkCore.Migrations;

namespace FavoriteMovies.EntityFramework.Migrations
{
    public partial class AddMovieAndCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndDirector_Movies_MovieId",
                table: "MovieAndDirector");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndDirector_People_DirectorId",
                table: "MovieAndDirector");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndLanguage_Languages_LanguageId",
                table: "MovieAndLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndLanguage_Movies_MovieId",
                table: "MovieAndLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Countries_CountryId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CountryId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieAndLanguage",
                table: "MovieAndLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieAndDirector",
                table: "MovieAndDirector");

            migrationBuilder.RenameTable(
                name: "MovieAndLanguage",
                newName: "MovieAndLanguages");

            migrationBuilder.RenameTable(
                name: "MovieAndDirector",
                newName: "MovieAndDirectors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndLanguage_MovieId",
                table: "MovieAndLanguages",
                newName: "IX_MovieAndLanguages_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndLanguage_LanguageId",
                table: "MovieAndLanguages",
                newName: "IX_MovieAndLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndDirector_MovieId",
                table: "MovieAndDirectors",
                newName: "IX_MovieAndDirectors_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndDirector_DirectorId",
                table: "MovieAndDirectors",
                newName: "IX_MovieAndDirectors_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieAndLanguages",
                table: "MovieAndLanguages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieAndDirectors",
                table: "MovieAndDirectors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MovieAndCountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieAndCountry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieAndCountry_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieAndCountry_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieAndCountry_CountryId",
                table: "MovieAndCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieAndCountry_MovieId",
                table: "MovieAndCountry",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndDirectors_Movies_MovieId",
                table: "MovieAndDirectors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndDirectors_People_DirectorId",
                table: "MovieAndDirectors",
                column: "DirectorId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndLanguages_Languages_LanguageId",
                table: "MovieAndLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndLanguages_Movies_MovieId",
                table: "MovieAndLanguages",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndDirectors_Movies_MovieId",
                table: "MovieAndDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndDirectors_People_DirectorId",
                table: "MovieAndDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndLanguages_Languages_LanguageId",
                table: "MovieAndLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAndLanguages_Movies_MovieId",
                table: "MovieAndLanguages");

            migrationBuilder.DropTable(
                name: "MovieAndCountry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieAndLanguages",
                table: "MovieAndLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieAndDirectors",
                table: "MovieAndDirectors");

            migrationBuilder.RenameTable(
                name: "MovieAndLanguages",
                newName: "MovieAndLanguage");

            migrationBuilder.RenameTable(
                name: "MovieAndDirectors",
                newName: "MovieAndDirector");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndLanguages_MovieId",
                table: "MovieAndLanguage",
                newName: "IX_MovieAndLanguage_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndLanguages_LanguageId",
                table: "MovieAndLanguage",
                newName: "IX_MovieAndLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndDirectors_MovieId",
                table: "MovieAndDirector",
                newName: "IX_MovieAndDirector_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAndDirectors_DirectorId",
                table: "MovieAndDirector",
                newName: "IX_MovieAndDirector_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieAndLanguage",
                table: "MovieAndLanguage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieAndDirector",
                table: "MovieAndDirector",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CountryId",
                table: "Movies",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndDirector_Movies_MovieId",
                table: "MovieAndDirector",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndDirector_People_DirectorId",
                table: "MovieAndDirector",
                column: "DirectorId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndLanguage_Languages_LanguageId",
                table: "MovieAndLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAndLanguage_Movies_MovieId",
                table: "MovieAndLanguage",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Countries_CountryId",
                table: "Movies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
