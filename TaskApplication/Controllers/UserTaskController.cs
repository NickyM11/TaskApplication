using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskApplication.DataAccessLayer;
using TaskApplication.Models;
using TaskApplication.Services;
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
            if (ModelState.IsValid)
            {
                IUserTaskService _userTaskService = new UserTaskService();
                string errorMessage;

                if (!_userTaskService.AddTaskToUser(taskId, UserId, addTaskToUserViewModel.Deadline, out errorMessage))
                {
                    return RedirectToAction("Display", "Error", new { errorMessage = errorMessage });
                }

                return RedirectToAction("Index", "Home");
            }

            return View(addTaskToUserViewModel);

            //using (var db = new TaskDbContext())
            //{
            //    Task TaskFromDb = db.Tasks.Find(taskId);
            //    User UserFromDb = db.Users.Find(UserId);

            //    if (TaskFromDb == null || UserFromDb == null)
            //    {
            //        return HttpNotFound();
            //    }

            //    UserTask UserTask = new UserTask()
            //    {
            //        User = User,
            //        Task = TaskFromDb,
            //        UserId = User.UserId,
            //        TaskId = TaskFromDb.TaskId,
            //        Deadline = addTaskToUserViewModel.Deadline
            //    };

            //    db.UserTasks.Add(UserTask);

            //    ModelState.AddModelError("adding", "something went wrong");

            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            //    {
            //        TempData["error"] = e;
            //        return RedirectToAction("Display", "Error");
            //    }
        }
    }
}