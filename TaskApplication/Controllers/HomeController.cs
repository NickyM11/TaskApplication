using System.Collections.Generic;
using System.Web.Mvc;
using TaskApplication.Models;
using TaskApplication.Services;

namespace TaskApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IUserTaskService _userTaskService= new UserTaskService();
            var usersWithTasks = _userTaskService.GetTasksPerUser();

            return View(usersWithTasks);
        }
    }
}