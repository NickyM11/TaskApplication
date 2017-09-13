using System;
using System.Web.Mvc;

namespace TaskApplication.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Display(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }
    }
}