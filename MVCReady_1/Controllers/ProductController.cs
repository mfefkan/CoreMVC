using Microsoft.AspNetCore.Mvc;
using MVCReady_1.Models.Context;
using MVCReady_1.Models.Entities;
using MVCReady_1.VMModels;

namespace MVCReady_1.Controllers
{
    public class ProductController : Controller
    {
        MyContext _db;
        public ProductController(MyContext db)
        {
            _db = db;
        }

        public IActionResult ListProducts()
        {
            return View(_db.Products.ToList());
            
        }

		public IActionResult AddProduct()
		{
            AddProductPageVM x = new AddProductPageVM
            {
                Categories = _db.Categories.Select(x => new CategoryVM
                {
                    ID = x.ID,
                    Description = x.Description,
                    CategoryName = x.CategoryName

                }).ToList(),
			};
			return View(x);
		}
		
		[HttpPost]
        public IActionResult AddProduct(ProductVM product) 
        {
            Product newProduct = new Product
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                ID = product.ID,
                Category = _db.Categories.Find(product.CategoryID)
            };

            _db.Products.Add(newProduct);
            _db.SaveChanges();
            
            return RedirectToAction("ListProducts");
        }
    }
}
