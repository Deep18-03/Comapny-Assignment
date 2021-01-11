using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Prodetails
    {
        public int pro_id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Nullable<int> Price { get; set; }
        public string Category { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ShortDescription { get; set; }

        public int Category_id { get; set; }
        public string Category_name { get; set; }

    
    }
}