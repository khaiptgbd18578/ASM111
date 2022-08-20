using Asm1670.Data;
using Asm1670.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Asm1670.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext context;
        public CartController(ApplicationDbContext Dbcontext)
        {
            this.context = Dbcontext;
        }

        public IActionResult Index()
        {
            var cart = context.Cart.ToList();
            return View(cart);
        }
    }
}
