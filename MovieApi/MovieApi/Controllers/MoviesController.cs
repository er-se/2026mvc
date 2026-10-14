using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ============================================================
        // ШАГ 5: LINQ-запросы на объединение данных из разных классов
        // ============================================================

        // 1. Фильмы с названием жанра (JOIN Movies + Genres)
        // GET: api/movies/with-genres
        [HttpGet("with-genres")]
        public async Task<ActionResult> GetMoviesWithGenres()
        {
            var result = await _context.Movies
                .Join(_context.Genres,
                      movie => movie.GenreId,
                      genre => genre.Id,
                      (movie, genre) => new
                      {
                          movie.Id,
                          movie.Title,
                          movie.Year,
                          movie.Price,
                          GenreName = genre.Name,
                          GenreDescription = genre.GetDescription()
                      })
                .ToListAsync();

            return Ok(result);
        }

        // 2. Средняя цена фильмов по жанрам (GROUP BY + LINQ)
        // GET: api/movies/avg-price-by-genre
        [HttpGet("avg-price-by-genre")]
        public async Task<ActionResult> GetAvgPriceByGenre()
        {
            var result = await _context.Movies
                .GroupBy(m => m.GenreId)
                .Select(g => new
                {
                    GenreId = g.Key,
                    GenreName = _context.Genres
                        .Where(genre => genre.Id == g.Key)
                        .Select(genre => genre.Name)
                        .FirstOrDefault(),
                    AveragePrice = g.Average(m => m.Price),
                    MovieCount = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }

        // 3. Топ-3 самых дорогих фильма (ORDER BY + TAKE + SELECT)
        // GET: api/movies/top-3-expensive
        [HttpGet("top-3-expensive")]
        public async Task<ActionResult> GetTop3Expensive()
        {
            var result = await _context.Movies
                .OrderByDescending(m => m.Price)
                .Take(3)
                .Select(m => new
                {
                    m.Title,
                    m.Price,
                    m.Year
                })
                .ToListAsync();

            return Ok(result);
        }

        // 4. Фильмы с положительными отзывами (JOIN Movies + Reviews + WHERE)
        // GET: api/movies/with-positive-reviews
        [HttpGet("with-positive-reviews")]
        public async Task<ActionResult> GetMoviesWithPositiveReviews()
        {
            var result = await _context.Movies
                .Join(_context.Reviews,
                      movie => movie.Id,
                      review => review.MovieId,
                      (movie, review) => new { movie, review })
                .Where(x => x.review.Rating >= 7)
                .Select(x => new
                {
                    MovieTitle = x.movie.Title,
                    x.review.Author,
                    x.review.Rating,
                    x.review.Comment,
                    RatingText = x.review.GetRatingText()
                })
                .ToListAsync();

            return Ok(result);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}