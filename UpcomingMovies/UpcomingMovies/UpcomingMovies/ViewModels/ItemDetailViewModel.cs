using UpcomingMovies.Responses;

namespace UpcomingMovies.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public MovieResponse Item { get; set; }
        public ItemDetailViewModel(MovieResponse item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
