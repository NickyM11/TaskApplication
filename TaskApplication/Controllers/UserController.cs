using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskApplication.DataAccessLayer;
using TaskApplication.Models;

namespace TaskApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (var db = new TaskDbContext())
            {
                List<User> users = db.Users.ToList();
                return View(users);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            User User = new User();
            return View(User);
        }

        [HttpPost]
        public ActionResult Add(User UserToAdd)
        {
            if(ModelState.IsValid)
            {
                using (var db = new TaskDbContext())
                {
                    db.Users.Add(UserToAdd);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(UserToAdd);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            using (var db = new TaskDbContext())
            {
                User User = db.Users.Find(id);
                
                if(User == null)
                {
                    return HttpNotFound();
                }
                return View(User);
            }     
        }

        [HttpPost]
        public ActionResult Edit(User UserToEdit)
        {
            if(ModelState.IsValid)
            {
                using (var db = new TaskDbContext())
                {
                    db.Entry(UserToEdit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(UserToEdit);
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            using (var db = new TaskDbContext())
            {
                User User = db.Users.Find(id);

                if (User == null)
                {
                    return HttpNotFound();
                }

                return View(User);
            }
        }

        [HttpPost]
        public ActionResult Delete(User UserToDelete)
        {
            if (ModelState.IsValid)
            {
                using (var db = new TaskDbContext())
                {
                    db.Entry(UserToDelete).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(UserToDelete);
        }
    }
}
