using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Comedy" },
                    { 4, "Sci-Fi" },
                    { 5, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "GenreId", "Price", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, 19.99m, "The Matrix", 1999 },
                    { 2, 4, 14.99m, "Inception", 2010 },
                    { 3, 2, 12.99m, "The Godfather", 1972 },
                    { 4, 2, 9.99m, "Titanic", 1997 },
                    { 5, 3, 7.99m, "The Hangover", 2009 },
                    { 6, 4, 16.99m, "Interstellar", 2014 },
                    { 7, 5, 11.99m, "The Conjuring", 2013 },
                    { 8, 1, 8.99m, "Die Hard", 1988 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Author", "Comment", "CreatedAt", "MovieId", "Rating" },
                values: new object[,]
                {
                    { 1, "Иван", "Классика!", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 2, "Мария", "Отличный фильм", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 3, "Пётр", "Захватывает дух", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 4, "Анна", "Шедевр на все времена", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10 },
                    { 5, "Сергей", "Нормально, но длинно", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 6 },
                    { 6, "Ольга", "Смешно", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7 },
                    { 7, "Дмитрий", "Лучший sci-fi", new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 9 },
                    { 8, "Елена", "Страшно, но банально", new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 5 },
                    { 9, "Алексей", "Классический боевик", new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
