﻿using Asm1670.Data;
using Asm1670.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asm1670.Controllers
{
    public class RequestController : Controller
    {
        private ApplicationDbContext context;
        public RequestController(ApplicationDbContext Dbcontext)
        {
            this.context = Dbcontext;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                context.Add(request);
                context.SaveChanges();
                TempData["Message"] = "Add Request successfully !";
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }
        public IActionResult Index()
        {
            return View(context.category.ToList());
        }
        public IActionResult Approve(int Id)
        {
            var request = context.Request.Find(Id);
            var category = new Category();
            category.CategoryName = request.RequestName;
            if (ModelState.IsValid)
            {
                context.Add(category);
                context.Request.Remove(request);
                context.SaveChanges();
                TempData["Message"] = "Approve Successfully";
                return RedirectToAction("Index");
            }
            return View(context.category.ToList());
        }
        public IActionResult ReviewRequest()
        {
            return View(context.Request.ToList());
        }
        public IActionResult Reject(int id)
        {
            var request = context.Request.Find(id);
            context.Request.Remove(request);
            context.SaveChanges();
            TempData["Message"] = "Reject category";
            return RedirectToAction("Index");
        }
    }
}
