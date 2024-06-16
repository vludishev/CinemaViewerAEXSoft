using CV.App.ViewModels;

namespace CV.App.Pages;

public partial class FilmDetailPage : ContentPage
{
    private readonly FilmDetailViewModel _viewModel;

    public FilmDetailPage(FilmDetailViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}