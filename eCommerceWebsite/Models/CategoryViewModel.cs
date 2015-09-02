using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceWebsite.Models
{
    public class CategoryViewModel
    {
        public List<ProductResult> Products { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
    }
}