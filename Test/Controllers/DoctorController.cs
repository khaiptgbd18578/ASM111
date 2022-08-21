using Microsoft.AspNetCore.Mvc;
using Test.Data;

namespace Test.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext context;
        public DoctorController(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        public IActionResult Store()
        {
            return View();
        }

        
    }
}
