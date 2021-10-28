using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mongoExample.Models;

namespace mongoExample.Controllers
{
    public class displayController : Controller
    
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public displayController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        // GET
        public IActionResult Index(string s)
        {
            var users = _userManager.Users.ToList();
            return Content(s);
        }
    }
}