using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Linq;
using UpcomingMovies.Services;
using UpcomingMovies.Responses;

namespace UpcomingMovies.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<MovieResponse> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command<string> SearchItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<MovieResponse>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SearchItemsCommand = new Command<string>(async (string search) => await ExecuteSearchItemsCommand(search));
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var movieService = new MovieService();
                var movies = await movieService.GetMoviesAsync();

                foreach (var item in movies.Results.OrderBy(movie => movie.Title))
                    Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteSearchItemsCommand(string search)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var movieService = new MovieService();
                var movies = await movieService.SearchForAMovieByName(search);

                foreach (var item in movies.Results.OrderBy(movie => movie.Title))
                    Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}