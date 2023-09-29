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

        public IActionResult UpdateProduct(int id)
        {
            Product willBeUpdated = _db.Products.Find(id);

            ProductVM wilBeUpdatedProductVM = new ProductVM
            {
                ProductName = willBeUpdated.ProductName,
                UnitPrice = willBeUpdated.UnitPrice,
                ID = willBeUpdated.ID

            };

            AddProductPageVM willBeUpdatedProductPageVM = new AddProductPageVM
            {
                Categories = _db.Categories.Select(x => new CategoryVM
                {
                    ID = x.ID,
                    Description = x.Description,
                    CategoryName = x.CategoryName
                }).ToList(),
                Product = wilBeUpdatedProductVM
            };

            return View(willBeUpdatedProductPageVM);
        }
        [HttpPost]
        public IActionResult UpdateProduct(ProductVM product)
        {
            Product toBeUpdated = _db.Products.Find(product.ID);

            toBeUpdated.ProductName = product.ProductName;
            toBeUpdated.UnitPrice = product.UnitPrice;
            toBeUpdated.Category = _db.Categories.Find(product.CategoryID);
            toBeUpdated.ID = product.ID;

            _db.Update(toBeUpdated);
            _db.SaveChanges();

            return RedirectToAction("ListProducts");
        }

        public ActionResult DeleteProduct(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

    }
}
