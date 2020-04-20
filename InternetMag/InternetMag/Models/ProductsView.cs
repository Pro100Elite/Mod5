using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetMag.Models
{
    public class ProductsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int categoryId { get; set; }
    }
}