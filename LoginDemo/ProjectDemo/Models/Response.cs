using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class Response<T>
    {
        public bool status { get; set; }
        public T value { get; set; }
        public string msg { get; set; }
    }
}