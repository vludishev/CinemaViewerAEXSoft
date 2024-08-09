using CV.App.Services;
using CV.App.Shared.TemplateModels;
using System.Collections.ObjectModel;

namespace CV.App.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public ObservableCollection<NewsItem> News { get; } =
        [
            new NewsItem()
            {
                Text = "БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ" +
                " БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ",
            },
            new NewsItem()
            {
                Resources = 
                [
                    new InternetResource() {
                        MediaType = MediaType.Picture,
                        Uri = "https://coop-land.ru/uploads/posts/2019-07/1562267530_1561561111_11.jpg"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Video,
                        Uri = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Picture,
                        Uri = "https://coop-land.ru/uploads/posts/2019-07/1562267530_1561561111_11.jpg"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Video,
                        Uri = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
                    },
                ],
                Text = "БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ" +
                " БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ",
            },
            new NewsItem()
            {
                Text = "БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ" +
                " БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ",
            },
            new NewsItem()
            {
                Resources =
                [
                    new InternetResource() {
                        MediaType = MediaType.Picture,
                        Uri = "https://coop-land.ru/uploads/posts/2019-07/1562267530_1561561111_11.jpg"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Video,
                        Uri = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Picture,
                        Uri = "https://coop-land.ru/uploads/posts/2019-07/1562267530_1561561111_11.jpg"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Video,
                        Uri = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
                    },
                ],
                Text = "БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ" +
                " БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ",
            },
             new NewsItem()
            {
                Text = "БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ" +
                " БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ",
            },
            new NewsItem()
            {
                Resources =
                [
                    new InternetResource() {
                        MediaType = MediaType.Picture,
                        Uri = "https://coop-land.ru/uploads/posts/2019-07/1562267530_1561561111_11.jpg"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Video,
                        Uri = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Picture,
                        Uri = "https://coop-land.ru/uploads/posts/2019-07/1562267530_1561561111_11.jpg"
                    },
                    new InternetResource() {
                        MediaType = MediaType.Video,
                        Uri = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
                    },
                ],
                Text = "БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ" +
                " БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ БОЛЬШОЙ ТЕКСТ",
            },
        ];

        private readonly IFilmsService _filmsService;
        public NewsViewModel(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }
    }
}
