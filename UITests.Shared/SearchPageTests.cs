using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace UITests
{
    public class SearchPageTests : BaseTest
    {
        private const string expectedFilmName = "Dawn of the Dead";

        private void PerformSearch(string query)
        {
            var searchBar = FindUIElement("SearchBar");
            Assert.That(searchBar, Is.Not.Null, "SearchBar not found");

            searchBar.Click();
            searchBar.Clear();
            searchBar.SendKeys(query);
            SearchBtnClick();
        }

        private void AssertFilmAttributes()
        {
            var searchResults = FindUIElement("SearchResults");
            Assert.That(searchResults, Is.Not.Null, "SearchResults not found");

            var posters = FindUIElements("FilmPoster");
            var names = FindUIElements("FilmName");
            var descriptions = FindUIElements("FilmDescription");
            var ratings = FindUIElements("FilmRating");

            Assert.That(posters.Count > 0, "No film posters found");
            Assert.That(names.Count > 0 && !names.Any(x => string.IsNullOrEmpty(x.Text)), "Invalid film names found");
            Assert.That(descriptions.Count > 0 && !descriptions.Any(x => string.IsNullOrEmpty(x.Text)), "Invalid film descriptions found");
            Assert.That(ratings.Count > 0 && !ratings.Any(x => string.IsNullOrEmpty(x.Text)), "Invalid film ratings found");
        }

        [Test]
        public void FilmsDisplayTest()
        {
            PerformSearch("Action");
            AssertFilmAttributes();
        }

        [Test]
        public void SearchBarInputTest()
        {
            PerformSearch(" horror ");
            Assert.That(FindUIElement("SearchResults"), Is.Not.Null, "SearchResults not found");

            PerformSearch(" HOR");
            Assert.That(FindUIElement("SearchResults"), Is.Not.Null, "SearchResults not found");

            PerformSearch(" .{}  dawn     .... of the dead");
            Assert.That(FindUIElement("SearchResults"), Is.Not.Null, "SearchResults not found");
        }

        [Test]
        public void EnterDiffFilmAttributesTest()
        {
            PerformSearch("sarah polley");
            var names = FindUIElements("FilmName");
            var foundFilm = names.FirstOrDefault(x => x.Text.Equals(expectedFilmName, StringComparison.InvariantCultureIgnoreCase));
            Assert.That(foundFilm, Is.Not.Null, "Film not found for actor 'sarah polley'");

            PerformSearch("horror");
            names = FindUIElements("FilmName");
            foundFilm = names.FirstOrDefault(x => x.Text.Equals(expectedFilmName, StringComparison.InvariantCultureIgnoreCase));
            Assert.That(foundFilm, Is.Not.Null, "Film not found for genre 'horror'");

            PerformSearch("dawn of the dead");
            names = FindUIElements("FilmName");
            foundFilm = names.FirstOrDefault(x => x.Text.Equals(expectedFilmName, StringComparison.InvariantCultureIgnoreCase));
            Assert.That(foundFilm, Is.Not.Null, "Film not found for title 'dawn of the dead'");
        }

        [Test]
        public void CheckTransition()
        {
            PerformSearch(expectedFilmName);

            var filmNames = FindUIElements("FilmName");
            var foundFilm = filmNames.FirstOrDefault(x => x.Text.Equals(expectedFilmName, StringComparison.InvariantCultureIgnoreCase));
            Assert.That(foundFilm, Is.Not.Null, "Film not found");

            foundFilm.Click();
            Task.Delay(2000).Wait();

            var filmDetailPage = FindUIElement("FilmDetailPage");
            Assert.That(filmDetailPage, Is.Not.Null, "Transition to FilmDetailPage not executed");

            App.Navigate().Back();
            Task.Delay(2000).Wait();

            var searchPage = FindUIElement("SearchPage");
            Assert.That(searchPage, Is.Not.Null, "Transition back to SearchPage not executed");
        }
    }
}
