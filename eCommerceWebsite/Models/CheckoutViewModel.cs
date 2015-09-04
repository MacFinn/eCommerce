using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceWebsite.Models
{
    public class CheckoutViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}