using CV.App.ViewModels;

namespace CV.App.Pages;

public partial class NewsPage : ContentPage
{
    private readonly NewsViewModel _viewModel;

    public NewsPage(NewsViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
        Appearing += async (s, e) =>
        {
            await _viewModel.InitializeAsync();
        };
    }
}