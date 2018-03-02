
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UpcomingMovies.ViewModels;
using UpcomingMovies.Responses;
using System;

namespace UpcomingMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MovieResponse;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = MovieNameSearchBar.Text;
            if (string.IsNullOrEmpty(search))
                viewModel.LoadItemsCommand.Execute(null);
            if (search.Length >= 3)
                viewModel.SearchItemsCommand.Execute(search);
        }
    }
}