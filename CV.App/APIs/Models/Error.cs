using CV.App.APIs.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.APIs.Models
{
    public class Error
    {
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}
