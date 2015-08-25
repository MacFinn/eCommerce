using eCommerceWebsite.App_Data;
using eCommerceWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWebsite.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Browse(string category)
        {
            ProductsDataContext db = new ProductsDataContext();

            var query = from p in db.Products
                        where p.Category == category
                        select new { p.Category, p.Description, p.Id, p.ImageUrl, p.Name, p.Price, p.Stock };

            var results = new List<ProductResult>();

            foreach (var q in query)
            {
                var result = new ProductResult
                {
                    Name = q.Name,
                    Category = q.Category,
                    Price = (double)q.Price,
                    ImageUrl = q.ImageUrl,
                    Description = q.Description,
                    Stock = q.Stock,
                    Id = q.Id
                };

                results.Add(result);
            }

            CategoryViewModel model = new CategoryViewModel();
            model.Products = results;

            return View(category, model);
        }

        public ActionResult Details(ProductResult model)
        {
            int id = model.Id;
            model = getDetailsFromId(id);
            return View("Details", model);
        }

        private ProductResult getDetailsFromId(int id)
        {
            ProductsDataContext db = new ProductsDataContext();
            var query = from p in db.Products
                        where p.Id == id
                        select new { p.Category, p.Description, p.Id, p.ImageUrl, p.Name, p.Price, p.Stock };

            var result = new ProductResult
            {
                Name = query.First().Name,
                Category = query.First().Category,
                Price = (double)query.First().Price,
                ImageUrl = query.First().ImageUrl,
                Description = query.First().Description,
                Stock = query.First().Stock,
                Id = query.First().Id
            };

            return result;
        }
	}
}