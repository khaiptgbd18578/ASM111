using Asm1670.Data;
using Asm1670.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsmDotNet.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext context;
        public BookController(ApplicationDbContext Dbcontext)
        {
            this.context = Dbcontext;
        }

        [Authorize(Roles = "Customer, Store Owner, Admin")]
        public IActionResult ViewBook()
        {
            var book = context.Book.ToList();
            return View(book);
        }

        [Authorize(Roles = "Customer, Store Owner, Admin")]
        public IActionResult Index()
        {
            var index = context.Book.ToList();
            return View(index);
        }

        [Authorize(Roles = "Customer, Store Owner, Admin")]
        public IActionResult Detail(int? id)
        {
            var book = context.Book
                .Include(e => e.Category)
                .FirstOrDefault(m => m.Id == id);
            return View(book);
        }

        [Authorize(Roles = "Store Owner, Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();

            return RedirectToAction(nameof(ViewBook));
        }

        [Authorize(Roles = "Customer")]
        public IActionResult AddCart()
        {
            
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Store Owner, Admin")]

        public IActionResult Create()
        {

            var cart = context.Cart.ToList();
            ViewBag.Cart = cart;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Store Owner, Admin")]

        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Book.Add(book);
                context.SaveChanges();
                return RedirectToAction("ViewBook");

            }
            return View(book);
        }
        [Authorize(Roles = "Store Owner, Admin")]

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            var author = context.Cart.ToList();
            return View(book);
        }
        [Authorize(Roles = "Store Owner, Admin")]


        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Book.Update(book);
                context.SaveChanges();
                return RedirectToAction("ViewBook");
            }
            return View(book);
        }

    }
}
