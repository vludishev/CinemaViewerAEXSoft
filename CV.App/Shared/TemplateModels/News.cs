using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.Shared.TemplateModels
{
    public enum MediaType
    {
        Picture,
        Video
    }

    public class InternetResource
    {
        public string Uri { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
    }

    public class NewsItem
    {
        public List<InternetResource> Resources { get; set; } = [];
        public string Text { get; set; } = string.Empty;
    }
}
