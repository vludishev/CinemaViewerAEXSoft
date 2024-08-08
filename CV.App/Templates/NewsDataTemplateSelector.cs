using CV.App.Shared.TemplateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.Templates
{
    public class NewsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NewsPicture { get; set; }
        public DataTemplate NewsVideo { get; set; }
        public DataTemplate NewsText { get; set; }

        // ДО 10 медиа-элементов и текст
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is not IEnumerable<News> news)
            {
                throw new InvalidCastException($"Argument {nameof(item)} " +
                    $"in method {nameof(OnSelectTemplate)} is not IEnumerable<News>");
            }

            var generator = new DataTemplateGenerator(news, CreateDefaultDataTemplate());
            return generator.GetDataTemplate();
        }

        private DataTemplate CreateDefaultDataTemplate()
        {
            return new DataTemplate();
        }
    }

    public class DataTemplateGenerator
    {
        private DataTemplate _template;
        private IEnumerable<News> _news;

        public DataTemplateGenerator(IEnumerable<News> news, DataTemplate template)
        {
            _template = template 
                ?? throw new ArgumentException($"Argument {nameof(template)} " +
                    $"in ctor {nameof(DataTemplateGenerator)} is null");
            _news = news;
        }

        private void AddPictureToTemplate()
        {
            //_template = new DataTemplate(() => {
                
               
            //});

            //var label = new Label();
            //label.SetBinding(Label.TextProperty, new Binding("."));
            //return label;
        }

        private void AddVideoToTemplate()
        {

        }

        private void AddTextToTemplate()
        {

        }

        public DataTemplate GetDataTemplate()
        {

            foreach (var item in _news)
            {
                switch (item.Type)
                {
                    case NewsType.WithPicture:
                        AddPictureToTemplate();
                        break;
                    case NewsType.WithVideo:
                        AddVideoToTemplate();
                        break;
                    default:
                        AddTextToTemplate();
                        break;
                }
            }

            return _template;
        }
    }
}
