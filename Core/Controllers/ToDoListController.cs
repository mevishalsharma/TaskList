using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataContext;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Core.Controllers
{
    public class ToDoListController : BaseController
    {
        private TaskDBContext _context;

        public ToDoListController(TaskDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var task = _context.TaskList.Where(x => x.TaskUserId == Convert.ToInt32(HttpContext.Session.GetString("UserLog"))).ToList();
            return View(task);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskListModel task)
        {
            var newID = _context.TaskList.Select(x => x.ID).Max() + 1;
            task.ID = newID;
            task.UpdatedDate = DateTime.Now;
            task.TaskUserId = Convert.ToInt32(HttpContext.Session.GetString("UserLog"));


            _context.TaskList.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _context.TaskList.Remove(_context.TaskList.Find(id));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.TaskList.Find(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskListModel task)
        {
            task.UpdatedDate = DateTime.Now;
            task.TaskUserId = Convert.ToInt32(HttpContext.Session.GetString("UserLog"));
            _context.TaskList.Update(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}