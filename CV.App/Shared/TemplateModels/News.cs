using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.Shared.TemplateModels
{
    public enum NewsType
    {
        OnlyText,
        WithPicture,
        WithVideo
    }

    public class News
    {
        public NewsType Type { get; set; }
        public string Picture { get; set; }
        public string Video { get; set; }
        public string Text { get; set; }
    }
}
