using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleDemoMVC.Models.Data
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        
    }
}