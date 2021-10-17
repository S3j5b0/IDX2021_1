using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mongoExample.Controllers
{
    [Authorize]
    public class SecureController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}