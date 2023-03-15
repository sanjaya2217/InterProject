using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace InterviewApp.Models
{
    //API Response
    public class APIResult
    {
        public HttpStatusCode statuscode { get; set; }
        public string? message { get; set; }
        public DateTime timestamp { get; set; }

    }

}