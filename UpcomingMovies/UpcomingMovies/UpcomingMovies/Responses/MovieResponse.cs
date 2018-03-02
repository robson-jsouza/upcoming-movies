using System;

namespace UpcomingMovies.Responses
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster_Path { get; set; }
        public int[] Genre_Ids { get; set; }
        public DateTime Release_Date { get; set; }
        public string Overview { get; set; }

        public string AllGenresNames { get; set; }
        public string SmallSizeImageURI
        {
            get
            {
                return $"{AppResources.Services.MOVIES_API_IMAGE_BASE_URL}{AppResources.Services.IMAGE_SIZE_W92}{Poster_Path}";
            }
        }
        public string NormalSizeImageURI
        {
            get
            {
                return $"{AppResources.Services.MOVIES_API_IMAGE_BASE_URL}{AppResources.Services.IMAGE_SIZE_W500}{Poster_Path}";
            }
        }
    }
}
