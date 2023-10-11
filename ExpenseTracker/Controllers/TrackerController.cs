using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class TrackerController : Controller
    {
        private readonly AppDbContext _db;

        public TrackerController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var values = _db.Trackers.ToList();
            var income = values.Where(i => !i.isExpense).Sum(a => a.Amount);
            var expense = values.Where(i => i.isExpense).Sum(a => a.Amount);
            var totalBalance = income - expense;
            ViewBag.Income = income;
            ViewBag.Expense = expense;
            ViewBag.TotalBalance = totalBalance;
            return View(values); 
        }

        [HttpPost]
        public IActionResult NewTracker(string Name, int Amount)
        {
            Tracker tracker = new Tracker();
            tracker.Name = Name;

            if (Amount < 0)
            {
                tracker.isExpense = true;
                tracker.Amount = Math.Abs(Amount); 
            }
            else
            {
                tracker.isExpense = false;
                tracker.Amount = Amount; 
            }

            _db.Trackers.Add(tracker);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var tracker = _db.Trackers.FirstOrDefault(x => x.Id == id); 
            _db.Trackers.Remove(tracker);
            _db.SaveChanges(); 
            return RedirectToAction("Index");   
        }

    }
}
