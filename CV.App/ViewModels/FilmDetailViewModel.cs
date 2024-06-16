using CommunityToolkit.Mvvm.ComponentModel;
using CV.App.Services;
using CV.App.Shared.Models;

namespace CV.App.ViewModels
{
    public partial class FilmDetailViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private FilmDto? film;

        private readonly IFilmsService _filmsService;
        public FilmDetailViewModel(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!query.TryGetValue(Constants.FilmIdProperty, out object? value))
            {
                return;
            }
            else if (value != null)
            {
                var film = await _filmsService.GetFilmInfo(Convert.ToInt32(value));
                Film = film;
                Title = film.Name;
            }
        }
    }
}
