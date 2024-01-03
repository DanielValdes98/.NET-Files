using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class AuthorizationResult
    {
        public GmailService service { get; set; }
        public string Message { get; set; }
    }
}