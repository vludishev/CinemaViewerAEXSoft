using CV.App.ViewModels;

#if __ANDROID__
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace CV.App
{
    public partial class App : Application
    {
        public App(SearchViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new AppShell(viewModel);
        }
    }
}
