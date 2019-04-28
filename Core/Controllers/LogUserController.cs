using Core.DataContext;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core.Controllers
{
    public class LogUserController : Controller
    {
        private TaskDBContext _context;

        public LogUserController(TaskDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Remove("UserLog");
            return View();
        }

        [HttpPost]
        public IActionResult Login(LogModel user)
        {
            var log = _context.LogModel.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (log != null) {
                HttpContext.Session.SetString("UserLog", log.ID.ToString());
                return RedirectToAction("Index", "ToDoList");
            }
            return RedirectToAction("Login");
        }
    }
}