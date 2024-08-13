using CV.App.APIs.Models;
using CV.App.Shared.TemplateModels;
using CV.Infrastructure;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace CV.App.APIs
{
    //public interface INewsApiClient
    //{
    //    Task<IEnumerable<NewsItem>> GetFilmNews();
    //}

    public class NewsApiClient
    {
        private readonly HttpClient _client;

        private readonly string newsApiKey = "238d7ae1fc0f468c8f2caf46e256be5d";

        public NewsApiClient()
        {
            _client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            _client.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
            _client.DefaultRequestHeaders.Add("x-api-key", newsApiKey);
        }

        public async Task<ArticlesResult> GetFilmNews()
        {
            var articlesResult = new ArticlesResult();

            Uri uri = new Uri(string.Format($"https://newsapi.org/v2/everything?q=movie&from={DateTime.Now.AddDays(-7):yyyy-MM-dd}&to={DateTime.Now:yyyy-MM-dd}&sortBy=publishedAt&apiKey={newsApiKey}", string.Empty));
            //&from=2024-08-12&to=2024-08-12&sortBy=popularity
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);

                    articlesResult.TotalResults = apiResponse.TotalResults;
                    articlesResult.Articles = apiResponse.Articles;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return articlesResult!;
        }
    }
}
