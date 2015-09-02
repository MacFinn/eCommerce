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
            CategoryViewModel model = new CategoryViewModel();
            model.Products = getResultsByCategory(category);

            if (model.Products.Count > 8)
            {
                double count = model.Products.Count / 8;
                model.TotalPages = (int)Math.Ceiling(count);
                model.CurrentPage = 1;
            }
            else
            {
                model.TotalPages = 1;
                model.CurrentPage = 1;
            }



            model.Products = model.Products.GetRange(0, 8);

            
            model.CurrentCategory = category;

            return View(model.CurrentCategory, model);
        }

        public List<ProductResult> getResultsByCategory(string category)
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
            return results;
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

        public ActionResult GoToPage(int page, string category)
        {
            string CurrentCategory = category;
            List<ProductResult> allResults = getResultsByCategory(category);
            int firstResultIndex = (page - 1) * 8;
            int resultCount = 8;
            var selectedResults = allResults.GetRange(firstResultIndex, resultCount);

            CategoryViewModel model = new CategoryViewModel();

            model.Products = selectedResults;
            model.CurrentPage = page;
            model.TotalPages = (int)Math.Ceiling((double)allResults.Count / 8);
            model.CurrentCategory = category;

            return View(category, model);
        }
	}
}