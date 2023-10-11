using Microsoft.AspNetCore.Mvc;
using Rock.Data;
using Rock.Models;

namespace Rock.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db; 
        }

        public IActionResult Index()
        {
            var categories = _db.Categories.ToList(); 
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);  

        }

        public IActionResult Edit(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id); 
            if(category == null)
            {
                return NotFound(); 
            }
            return View(category); 
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);  
            if(category == null)
            {
                return NotFound(); 
            }
            return View(category); 
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id); 
            if(category == null)
            {
                return BadRequest(); 
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}
