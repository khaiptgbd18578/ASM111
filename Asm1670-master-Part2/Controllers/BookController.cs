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

        [Authorize(Roles = "Admin")]
        public IActionResult ViewBook()
        {

            var books = context.Book.OrderByDescending(m => m.Id).ToList();
            return View(books);
        }

        [Authorize(Roles = "Customer, Storeowner")]
        //hiển thị giao diện dạng card cho khách hàng order sản phẩm
        public IActionResult Store()
        {
            return View(context.Book.ToList());
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
            TempData["Message"] = "Delete a book from the store successfully !";
            return RedirectToAction("View");
        }


        [Authorize(Roles = "Admin, Customer")]
        public IActionResult Detail(int id)
        {
            var mobile = context.Book.Include(m => m.Category).FirstOrDefault(b => b.Id == id);
            return View(mobile);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = context.category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            //check tính hợp lệ của dữ liệu 
            if (ModelState.IsValid)
            {
                //add dữ liệu vào DB
                context.Add(book);
                context.SaveChanges();
                //hiển thị thông báo thành công về view
                TempData["Message"] = "Add a new book successfully !";
                //quay ngược về trang index
                return RedirectToAction(nameof(View));
            }
            //nếu dữ liệu không hợp lệ thì trả về form để nhập lại
            return View(book);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Category = context.category.ToList();
            return View(context.Book.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Update(book);
                context.SaveChanges();
                TempData["Message"] = "Edit the chosen book successfully !";
                return RedirectToAction(nameof(View));
            }
            return View(book);
        }

    }
}
