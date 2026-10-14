namespace MovieApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Бизнес-логика: описание жанра
        public string GetDescription()
        {
            return Name switch
            {
                "Action" => "Боевик — фильмы с драками и погонями",
                "Drama" => "Драма — фильмы с глубоким сюжетом",
                "Comedy" => "Комедия — фильмы для поднятия настроения",
                "Sci-Fi" => "Фантастика — фильмы о будущем и технологиях",
                "Horror" => "Ужасы — фильмы, которые пугают",
                _ => "Другой жанр"
            };
        }

        // Бизнес-логика: является ли жанр "серьёзным"
        public bool IsSerious()
        {
            return Name == "Drama" || Name == "Action";
        }
    }
}