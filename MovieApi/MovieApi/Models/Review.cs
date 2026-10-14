namespace MovieApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Бизнес-логика: положительный ли отзыв
        public bool IsPositive()
        {
            return Rating >= 7;
        }

        // Бизнес-логика: отрицательный ли отзыв
        public bool IsNegative()
        {
            return Rating <= 3;
        }

        // Бизнес-логика: текстовое описание оценки
        public string GetRatingText()
        {
            return Rating switch
            {
                >= 9 => "Шедевр",
                >= 7 => "Отличный фильм",
                >= 5 => "Неплохо",
                >= 3 => "Так себе",
                _ => "Ужасно"
            };
        }
    }
}