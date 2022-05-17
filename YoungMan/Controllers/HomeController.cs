using Microsoft.AspNetCore.Mvc;

namespace YoungMan.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}