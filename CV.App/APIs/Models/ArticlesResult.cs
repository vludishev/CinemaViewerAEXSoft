using CV.App.APIs.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.APIs.Models
{
    public class ArticlesResult
    {
        public Statuses Status { get; set; }
        public Error Error { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}
