using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
