using System;
using System.Web.Mvc;

namespace TaskApplication.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Display()
        {
            Exception e =  (Exception) TempData["error"];

            ViewBag.Error = e.Message;
            return View();
        }
    }
}