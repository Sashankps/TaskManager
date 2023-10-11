using Microsoft.AspNetCore.Mvc;
using Rock.Data;
using Rock.Models;

namespace Rock.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly AppDbContext _db;

        public ApplicationTypeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var list = _db.ApplicationTypes.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApplicationType  obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int id)
        {
            var obj = _db.ApplicationTypes.SingleOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationType obj)
        {
            _db.ApplicationTypes.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var obj = _db.ApplicationTypes.FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeleteAppType(int id)
        {
            var obj = _db.ApplicationTypes.FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return BadRequest();
            }
            _db.ApplicationTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
