using CV.App.Services;
using CV.App.Shared.TemplateModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public ObservableCollection<News> News { get; } = new()
        {
            new News()
            {
                Type = NewsType.OnlyText,
                Picture = "",
                Video = "",
                Text = "",
            },
            new News()
            {
                Type = NewsType.WithPicture,
                Picture = "",
                Video = "",
                Text = "",
            },
            new News()
            {
                Type = NewsType.WithVideo,
                Picture = "",
                Video = "",
                Text = "",
            }
        };

        private readonly IFilmsService _filmsService;
        public NewsViewModel(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }
    }
}
