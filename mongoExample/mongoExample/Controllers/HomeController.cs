using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mongoExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;

namespace mongoExample.Controllers
{


    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _logger = logger;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            ApplicationUser usr = _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult();

            var friends = usr.friends;


            var usrs = _userManager.Users.ToList().FindAll(x => friends.Contains(x.NormalizedEmail));

            var displayUsers = usrs.Select<ApplicationUser, User>(x => new User()
            {
                name = x.UserName,
                email = x.Email,
                EconomicModel = x.EconomicModel,
                EnviormentalStats = x.EnviormentalStats,
                status = x.status,
                Color = x.Color

            }).ToList();
            // sig selv 
            ApplicationUser loggedin = _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult();
            User me = new User();


            me.email = loggedin.Email;
            me.status = loggedin.status;
            me.Color = loggedin.Color;
            me.EconomicModel = loggedin.EconomicModel;
            me.EnviormentalStats = loggedin.EnviormentalStats;

            


            Tuple<User, List<User>> modeltup =
                new Tuple<User, List<User>>(me, displayUsers);
            return View(modeltup);
        }
        [Authorize]
        public IActionResult updateStatus(string status)
        {
            ApplicationUser usr = _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult();
            usr.status = status;
            _userManager.UpdateAsync(usr).GetAwaiter().GetResult();
            return RedirectToAction("index");
        }
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        public IActionResult toggleMode()
        {

            CookieOptions option = new CookieOptions();
            if (Request.Cookies["mode"] == "env")
            {
                Response.Cookies.Append("mode", "monetary", option);
            } else if (Request.Cookies["mode"] == "monetary")
            {
                Response.Cookies.Append("mode", "env", option);
            }
            else
            {
                Response.Cookies.Append("mode", "monetary", option);
            }

            return RedirectToAction("Index");
        }
    }
}