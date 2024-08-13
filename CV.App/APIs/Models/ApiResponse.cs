﻿using CV.App.APIs.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.App.APIs.Models
{
    internal class ApiResponse
    {
        public Statuses Status { get; set; }
        public ErrorCodes? Code { get; set; }
        public string Message { get; set; }
        public List<Article> Articles { get; set; }
        public int TotalResults { get; set; }
    }
}
