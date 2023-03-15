using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InterviewAPI.Models
{

    // API Response Entity
    public class APIResult
    {

        public HttpStatusCode statuscode { get; set; }
        public string? message { get; set; }

        public DateTime timestamp { get; set; }


    }


}
