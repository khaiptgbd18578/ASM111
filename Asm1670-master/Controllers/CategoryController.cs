using Asm1670.Data;
using Asm1670.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Asm1670.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext context;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View(context.category.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Add(category);
                context.SaveChanges();
                TempData["Message"] = "Add Category successfully !";
                return RedirectToAction(nameof(Index));
            }
            return View(context.category.ToList());
        }
        public IActionResult Delete(int id)
        {
            var category = context.category.Find(id);
            context.category.Remove(category);
            context.SaveChanges();
            TempData["Message"] = "Delete Category successfully !";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(context.category.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Update(category);
                context.SaveChanges();
                TempData["Message"] = "Edit Category successfully !";
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }
        public IActionResult Detail(int id)
        {
            var category = context.category.Include(m => m.Book)
                                     .FirstOrDefault(b => b.Id == id);
            return View(category);
        }
    }
}
