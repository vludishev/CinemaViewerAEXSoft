using CV.App.Shared.TemplateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.Templates
{
    public class ResourceDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate VideoTemplate { get; set; }
        public DataTemplate PictureTemplate { get; set; }

        // ДО 10 медиа-элементов и текст
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is not InternetResource internetItem)
            {
                throw new InvalidCastException($"Argument {nameof(item)} " +
                    $"in method {nameof(OnSelectTemplate)} is not {nameof(InternetResource)}");
            }

            //if (newsItem.Videos.Count > 0 && newsItem.Pictures.Count > 0)
            //{
            //    return NewsFull;
            //} else if (newsItem.Videos.Count > 0 && newsItem.Pictures.Count <= 0)
            //{
            //    return NewsVideo;
            //} else if (newsItem.Videos.Count <= 0 && newsItem.Pictures.Count > 0)
            //{
            //    return NewsPicture;
            //}

            switch (internetItem.MediaType)
            {
                case MediaType.Picture:
                    return PictureTemplate;
                case MediaType.Video:
                    return VideoTemplate;
                default:
                    return null;
            }

            //var generator = new DataTemplateGenerator(news, CreateDefaultDataTemplate());
            //return generator.GetDataTemplate();

            
        }
    }

    //public class DataTemplateGenerator
    //{
    //    private DataTemplate _template;
    //    private News _news;

    //    public DataTemplateGenerator(News news, DataTemplate template)
    //    {
    //        _template = template 
    //            ?? throw new ArgumentException($"Argument {nameof(template)} " +
    //                $"in ctor {nameof(DataTemplateGenerator)} is null");
    //        _news = news;
    //    }

    //    private void AddPictureToTemplate()
    //    {
    //        //_template = new DataTemplate(() => {


    //        //});

    //        //var label = new Label();
    //        //label.SetBinding(Label.TextProperty, new Binding("."));
    //        //return label;
    //    }

    //    private void AddVideoToTemplate()
    //    {

    //    }

    //    private void AddTextToTemplate()
    //    {

    //    }

    //    public DataTemplate GetDataTemplate()
    //    {
    //        switch (_news.Type)
    //        {
    //            case NewsType.WithPicture:
    //                AddPictureToTemplate();
    //                return 
    //                break;
    //            case NewsType.WithVideo:
    //                AddVideoToTemplate();
    //                break;
    //            default:
    //                AddTextToTemplate();
    //                break;
    //        }

    //        return _template;
    //    }
    //}
}
