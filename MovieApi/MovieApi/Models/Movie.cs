namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }

        // Бизнес-логика: цена со скидкой
        public decimal GetDiscountedPrice(decimal discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
                throw new ArgumentException("Скидка должна быть от 0 до 100");

            return Price - (Price * discountPercent / 100);
        }

        // Бизнес-логика: старый ли фильм (до 2000 года)
        public bool IsOld()
        {
            return Year < 2000;
        }

        // Бизнес-логика: возраст фильма
        public int GetAge()
        {
            return DateTime.Now.Year - Year;
        }
    }
}