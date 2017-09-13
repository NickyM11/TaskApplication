using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskApplication.DataAccessLayer;
using TaskApplication.Models;
using TaskApplication.ViewModels;

namespace TaskApplication.Controllers
{
    public class UserTaskController : Controller
    {
        [HttpGet]
        public ActionResult AddTaskToUser(int id = 0)
        {
            using (var db = new TaskDbContext())
            {
                User UserFromDb = db.Users.Find(id);
                List<Task> TasksFromDb = db.Tasks.ToList();

                if (UserFromDb == null || TasksFromDb == null)
                {
                    return HttpNotFound();
                }

                AddTaskToUserViewModel addTaskToUserViewModel = new AddTaskToUserViewModel()
                {
                    User = UserFromDb,
                    Tasks = TasksFromDb
                };
                return View(addTaskToUserViewModel);
            }
        }

        [HttpPost]
        public ActionResult AddTaskToUser(AddTaskToUserViewModel addTaskToUserViewModel, int taskId, int UserId)
        {
            if(ModelState.IsValid)
            {
                using (var db = new TaskDbContext())
                {
                    Task TaskFromDb = db.Tasks.Find(taskId);
                    User User = db.Users.Find(UserId);
                    if (TaskFromDb == null)
                    {
                        return HttpNotFound();
                    }

                    UserTask UserTask = new UserTask()
                    {
                        User = User,
                        Task = TaskFromDb,
                        UserId = User.UserId,
                        TaskId = TaskFromDb.TaskId,
                        Deadline = addTaskToUserViewModel.Deadline
                    };

                    db.UserTasks.Add(UserTask);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
                        TempData["error"] = e;
                        return RedirectToAction("Display", "Error");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(addTaskToUserViewModel);
        }
    }
}