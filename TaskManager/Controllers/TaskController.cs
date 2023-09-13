using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _db;

        public TaskController(AppDbContext db)
        {
            _db = db; 
        }

        public IActionResult Index()
        {
            var taskListViewModels = _db.TaskListNames
                .Include(tln => tln.UserTasks)
                .ToList() // Retrieve all TaskListNames from the database
                .Select(t => new TaskListName
                {
                    Id = t.Id,
                    Name = t.Name,
                    CompletedTasks = t.UserTasks?.Count(ut => ut.IsCompleted) ?? 0,
                    PendingTasks = t.UserTasks?.Count(ut => !ut.IsCompleted) ?? 0
                })
                .ToList();
            Console.WriteLine(taskListViewModels.Count); 
            return View(taskListViewModels);
        }

        public IActionResult ShowTasks(int id)
        { 
            var TaskListName = _db.TaskListNames.Include(t=>t.UserTasks).FirstOrDefault(t => t.Id == id);
            if (TaskListName == null)
            {
                return RedirectToAction("Index");
            }
            return View(TaskListName);
        }

        [HttpPost]
        public IActionResult CreateNewTask(int Id, string name)
        {
            var newTask = new UserTask
            {
                Name = name,
                IsCompleted = false,
                TaskListNameId = Id,
            };
            _db.UserTasks.Add(newTask);
            _db.SaveChanges();
            return RedirectToAction("ShowTasks", new { Id });
        }

        [HttpPost]
        public IActionResult DeleteTask(int Id)
        {
            var task = _db.UserTasks.SingleOrDefault(t => t.Id == Id);
            var id = task.TaskListNameId; 
            if (task == null)
            {
                return NotFound();
            }

            _db.UserTasks.Remove(task);
            _db.SaveChanges();

            return RedirectToAction("ShowTasks", new { id });
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var task = _db.UserTasks.SingleOrDefault(t => t.Id == id);
            var Id = task?.TaskListNameId; 
            if(task == null)
            {
                return NotFound(); 
            }
            task.IsCompleted = true;
            _db.SaveChanges();
            return RedirectToAction("ShowTasks", new { Id });
        }

        [HttpPost]
        public IActionResult Undo(int id)
        {
            var task = _db.UserTasks.SingleOrDefault(t => t.Id == id);
            var Id = task?.TaskListNameId;
            if (task == null)
            {
                return NotFound();
            }
            task.IsCompleted = false;
            _db.SaveChanges();
            return RedirectToAction("ShowTasks", new { Id });
        }

        public IActionResult NewList()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult NewList(TaskListName model)
        {
            _db.TaskListNames.Add(model); 
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
