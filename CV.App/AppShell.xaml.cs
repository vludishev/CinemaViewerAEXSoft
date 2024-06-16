using CV.App.Pages;
using CV.App.ViewModels;

namespace CV.App;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

    public AppShell(SearchViewModel viewModel)
    {
        InitializeComponent();

        RegisterRoutes();
        BindingContext = this;
    }

    private void RegisterRoutes()
    {
        Routes.Add(Constants.FilmDetailsRoute, typeof(FilmDetailPage));

        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }
}