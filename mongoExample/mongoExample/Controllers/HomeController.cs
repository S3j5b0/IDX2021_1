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

namespace mongoExample.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            // sig selv 
            User me = new User();


            me.email = "sejsbo@live.dk";
            me.status = "een hanging out aalll, day ";
            me.Color = color.red;
            me.EconomicModel = new EconomicModel();
            me.EconomicModel.yearlySpending = 43;
            me.EconomicModel.WeeklyPrice = 735;
            me.EconomicModel.savedFromLastWeek = 2;
            me.EnviormentalStats = new EnviormentModel();
            me.EnviormentalStats.yearlySpending = 255;
            me.EnviormentalStats.savedFromLastWeek = 2323;
            me.EnviormentalStats.WeeklyKWHUsage = 4;
            
            // venner
            List<User> Users = new List<User>();

            User user1 = new User();
            user1.name = "calaaaa";
            user1.email = "carla@live.dk";
            user1.status = "doing it doing doing yes yes yes ";
            user1.Color = color.green;
            user1.EconomicModel = new EconomicModel();
            user1.EconomicModel.yearlySpending = 43;
            user1.EconomicModel.WeeklyPrice = 75;
            user1.EconomicModel.savedFromLastWeek = 2;
            user1.EnviormentalStats = new EnviormentModel();
            user1.EnviormentalStats.yearlySpending = 2355;
            user1.EnviormentalStats.savedFromLastWeek = 23;
            user1.EnviormentalStats.WeeklyKWHUsage = 9;

            Users.Add(user1);
            User user2 = new User();
            user2.name = "frederæk";
            user2.email = "frederik@live.dk";
            user2.status = "hack haxck hax ha x";
            user2.Color = color.yellow;
            user2.EconomicModel = new EconomicModel();
            user2.EconomicModel.yearlySpending = 231;
            user2.EconomicModel.WeeklyPrice = 200;
            user2.EconomicModel.savedFromLastWeek = 10;
            user2.EnviormentalStats = new EnviormentModel();
            user2.EnviormentalStats.yearlySpending = 1000;
            user2.EnviormentalStats.savedFromLastWeek = 500;
            user2.EnviormentalStats.WeeklyKWHUsage = 20;
            Users.Add(user2);


            Tuple<User, List<User>> modeltup =
                new Tuple<User, List<User>>(me, Users);
            return View(modeltup);
        }
        [Authorize]
        public IActionResult updateStatus()
        {
            
            return Content("TBD");
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