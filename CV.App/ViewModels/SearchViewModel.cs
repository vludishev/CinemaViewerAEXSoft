using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CV.App.Services;
using CV.App.Shared.Models;
using System.Collections.ObjectModel;

namespace CV.App.ViewModels
{
    public partial class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<SearchResult> SearchResults { get; } = new();

        private readonly IFilmsService _filmsService;
        public SearchViewModel(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        [RelayCommand]
        private async Task SelectFilmAsync(SearchResult result)
        {
            if (result != null && result.Id >= 0)
            {
                await Shell.Current.GoToAsync($"{Constants.FilmDetailsRoute}?{Constants.FilmIdProperty}={result.Id}");
            }
        }

        [RelayCommand]
        private async Task PerformSearchAsync(string? query)
        {
            try
            {
                if (query != null)
                {
                    var results = await _filmsService.GetSearchResultsAsync(Utility.GetClearQuery(query));
                    SearchResults.Clear();
                    foreach (var result in results)
                    {
                        SearchResults.Add(result);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException during search: {ex.Message}");
            }
        }
    }
}