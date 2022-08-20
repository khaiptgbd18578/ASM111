using Asm1670.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asm1670.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        public CustomerController(ApplicationDbContext Dbcontext)
        {
            this.context = Dbcontext;
        }
        public IActionResult Index()
        {
            var customer = context.Customer.ToList();
            return View(customer);
        }

    }
}
