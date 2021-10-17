using Microsoft.AspNetCore.Mvc;

namespace mongoExample.Controllers
{
    public class displayController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}