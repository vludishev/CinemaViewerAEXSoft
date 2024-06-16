using CV.App.ViewModels;

namespace CV.App.Pages;

public partial class SearchPage : ContentPage
{
    private readonly SearchViewModel _viewModel;
    public SearchPage(SearchViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void SearchBar_SearchButtonPressedAsync(object sender, EventArgs e)
    {
        if (SearchBar.IsSoftInputShowing())
            await SearchBar.HideSoftInputAsync(System.Threading.CancellationToken.None);
    }

    private void SearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is CollectionView collectionView)
        {
            collectionView.SelectedItem = null;
        }
    }
}