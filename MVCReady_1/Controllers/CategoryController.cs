using Microsoft.AspNetCore.Mvc;
using MVCReady_1.Models.Context;
using MVCReady_1.Models.Entities;

namespace MVCReady_1.Controllers
{
    public class CategoryController : Controller
    {
        MyContext _db;
        public CategoryController(MyContext db)
        {
            _db = db;
        }


        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category) 
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public IActionResult ListCategories() 
        {
            
            return View(_db.Categories.ToList());
        }

        public IActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public IActionResult UpdateCategory(int id)
        {
            Category c = _db.Categories.Find(id);

			return View(c);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            Category toBeUpdated = _db.Categories.Find(category.ID);
            toBeUpdated.CategoryName = category.CategoryName;
            toBeUpdated.Description = category.Description;
            _db.SaveChanges(true);
            return RedirectToAction("ListCategories");
        
        }

    }
}
