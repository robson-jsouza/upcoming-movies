using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UpcomingMovies.Responses;

namespace UpcomingMovies.API
{
    public class MovieAPI
    {
        public static async Task<MoviesResponse> GetMoviesAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync($"https://api.themoviedb.org/3/discover/movie?api_key={AppResources.Services.API_KEY}&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1");
                    var movies = JsonConvert.DeserializeObject<MoviesResponse>(json);
                    return movies;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<List<GenreResponse>> GetGenresOfTheMoviesAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync($"https://api.themoviedb.org/3/genre/movie/list?api_key={AppResources.Services.API_KEY}&language=en-US");
                    var allGenres = JsonConvert.DeserializeObject<GenresResponse>(json);
                    return allGenres.Genres;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<MoviesResponse> SearchForAMovieByName(string search)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync($"https://api.themoviedb.org/3/search/movie?api_key={AppResources.Services.API_KEY}&query={search}");
                    var movies = JsonConvert.DeserializeObject<MoviesResponse>(json);
                    return movies;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
