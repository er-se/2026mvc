using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Начальные данные для жанров
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Drama" },
                new Genre { Id = 3, Name = "Comedy" },
                new Genre { Id = 4, Name = "Sci-Fi" },
                new Genre { Id = 5, Name = "Horror" }
            );

            // Начальные данные для фильмов
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "The Matrix", Year = 1999, Price = 19.99m, GenreId = 1 },
                new Movie { Id = 2, Title = "Inception", Year = 2010, Price = 14.99m, GenreId = 4 },
                new Movie { Id = 3, Title = "The Godfather", Year = 1972, Price = 12.99m, GenreId = 2 },
                new Movie { Id = 4, Title = "Titanic", Year = 1997, Price = 9.99m, GenreId = 2 },
                new Movie { Id = 5, Title = "The Hangover", Year = 2009, Price = 7.99m, GenreId = 3 },
                new Movie { Id = 6, Title = "Interstellar", Year = 2014, Price = 16.99m, GenreId = 4 },
                new Movie { Id = 7, Title = "The Conjuring", Year = 2013, Price = 11.99m, GenreId = 5 },
                new Movie { Id = 8, Title = "Die Hard", Year = 1988, Price = 8.99m, GenreId = 1 }
            );

            // Начальные данные для отзывов
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, MovieId = 1, Author = "Иван", Rating = 10, Comment = "Классика!", CreatedAt = new DateTime(2024, 1, 1) },
                new Review { Id = 2, MovieId = 1, Author = "Мария", Rating = 8, Comment = "Отличный фильм", CreatedAt = new DateTime(2024, 1, 2) },
                new Review { Id = 3, MovieId = 2, Author = "Пётр", Rating = 9, Comment = "Захватывает дух", CreatedAt = new DateTime(2024, 1, 3) },
                new Review { Id = 4, MovieId = 3, Author = "Анна", Rating = 10, Comment = "Шедевр на все времена", CreatedAt = new DateTime(2024, 1, 4) },
                new Review { Id = 5, MovieId = 4, Author = "Сергей", Rating = 6, Comment = "Нормально, но длинно", CreatedAt = new DateTime(2024, 1, 5) },
                new Review { Id = 6, MovieId = 5, Author = "Ольга", Rating = 7, Comment = "Смешно", CreatedAt = new DateTime(2024, 1, 6) },
                new Review { Id = 7, MovieId = 6, Author = "Дмитрий", Rating = 9, Comment = "Лучший sci-fi", CreatedAt = new DateTime(2024, 1, 7) },
                new Review { Id = 8, MovieId = 7, Author = "Елена", Rating = 5, Comment = "Страшно, но банально", CreatedAt = new DateTime(2024, 1, 8) },
                new Review { Id = 9, MovieId = 8, Author = "Алексей", Rating = 8, Comment = "Классический боевик", CreatedAt = new DateTime(2024, 1, 9) }
            );
        }
    }
}