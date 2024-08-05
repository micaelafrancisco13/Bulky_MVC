using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db= db;
        }
        
        // VIEWS
        // creates the main controller of categories
        // which takes you to the Index view
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList); // returns the current view/page
        }

        // creates the POST controller of categories
        // which takes you to the POST view
        public IActionResult Create()
        {
            return View(); // returns the current view/page
        }
        // VIEWS

        // creates a POST endpoint for categories
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
