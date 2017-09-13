using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskApplication.DataAccessLayer;
using TaskApplication.Models;

namespace TaskApplication.Controllers
{
    public class TaskController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (var db = new TaskDbContext())
            {
                List<Task> Tasks = db.Tasks.ToList();
                return View(Tasks);
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            Task Task = new Task();
            return View(Task);
        }

        [HttpPost]
        public ActionResult Add(Task TaskToAdd)
        {
            if (ModelState.IsValid)
            {
                using (var db = new TaskDbContext())
                {
                    db.Tasks.Add(TaskToAdd);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(TaskToAdd);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            using (var db = new TaskDbContext())
            {
                Task Task = db.Tasks.Find(id);

                if (Task == null)
                {
                    return HttpNotFound();
                }
                return View(Task);
            }
        }

        [HttpPost]
        public ActionResult Edit(Task TaskToEdit)
        {
            if (ModelState.IsValid)
            {
                using (var db = new TaskDbContext())
                {
                    db.Entry(TaskToEdit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(TaskToEdit);
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            using (var db = new TaskDbContext())
            {
                Task Task = db.Tasks.Find(id);

                if (Task == null)
                {
                    return HttpNotFound();
                }
                return View(Task);
            }
        }

        [HttpPost]
        public ActionResult Delete(Task TaskToDelete)
        {
            if (ModelState.IsValid)
            {
                using (var db = new TaskDbContext())
                {
                    db.Entry(TaskToDelete).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(TaskToDelete);
        }
    }
}
