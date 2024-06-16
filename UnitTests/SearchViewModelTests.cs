using FluentAssertions;
using NSubstitute;
using CV.App.Services;
using CV.App.Shared.Models;
using CV.App.ViewModels;

namespace UnitTests
{
    public class SearchViewModelTests
    {
        [Fact]
        public async Task PerformSearchAsync_ShouldUpdateSearchResults()
        {
            var filmsService = Substitute.For<IFilmsService>();
            var viewModel = new SearchViewModel(filmsService);

            // Arrange
            var query = "Test";
            var results = new List<SearchResult>
            {
                new SearchResult { Id = 1, Name = "Test Film 1" },
                new SearchResult { Id = 2, Name = "Test Film 2" }
            };
            filmsService.GetSearchResultsAsync(Arg.Any<string>()).Returns(results);

            // Act
            await viewModel.PerformSearchCommand.ExecuteAsync(query);

            // Assert
            viewModel.SearchResults.Should().BeEquivalentTo(results);
        }
    }
}
