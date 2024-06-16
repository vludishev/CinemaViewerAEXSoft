using CommunityToolkit.Mvvm.ComponentModel;

namespace CV.App.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string? title;
    }
}
