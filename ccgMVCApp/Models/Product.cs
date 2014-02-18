using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccgMVCApp.Models
{
    [Serializable]
    public class Product
    {
        public string sku { get; set; }
        public string name { get; set; }
        public string quantity { get; set; }
        public string description { get; set; }
    }
}