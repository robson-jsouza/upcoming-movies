using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMovies.API;
using UpcomingMovies.Responses;

namespace UpcomingMovies.Services
{
    public class MovieService
    {
        public async Task<MoviesResponse> GetMoviesAsync()
        {
            var movies = await MovieAPI.GetMoviesAsync();
            var genres = await GetAllGenresAsync();
            foreach (var movie in movies.Results)
            {
                var genresOfTheMovie = genres?.Where(genre => movie.Genre_Ids.Contains(genre.Id));
                movie.AllGenresNames = genresOfTheMovie.Any() ? string.Join(", ", genresOfTheMovie.Select(genre => genre.Name)) : "Not informed.";
            }
            return movies;
        }

        public async Task<List<GenreResponse>> GetAllGenresAsync()
        {
            var genres = await MovieAPI.GetGenresOfTheMoviesAsync();
            return genres;
        }

        public async Task<MoviesResponse> SearchForAMovieByName(string movieName)
        {
            var movies = await MovieAPI.SearchForAMovieByName(movieName);
            var genres = await GetAllGenresAsync();
            foreach (var movie in movies.Results)
            {
                var genresOfTheMovie = genres?.Where(genre => movie.Genre_Ids.Contains(genre.Id));
                movie.AllGenresNames = genresOfTheMovie.Any() ? string.Join(", ", genresOfTheMovie.Select(genre => genre.Name)) : "Not informed.";
            }
            return movies;
        }
    }
}
