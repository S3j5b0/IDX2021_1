using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mongoExample.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mongoExample.Controllers

{
    public class UserController : Controller
    {
        protected ILookupNormalizer normalizer;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _RoleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._RoleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View();
        }  
        public IActionResult CreateRole()
        {
            return View();
        }  

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {

                var p = new Person(user.name, user.email);
                var json = JsonConvert.SerializeObject(p);

                string rez;
                try
                { 
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var url = "http://127.0.0.1:9999/createuser";
                    using var client = new HttpClient();
                    var response = client.PostAsync(url, data).GetAwaiter().GetResult();

                    rez = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    return Content("error accessing Watts API");
                }

                JObject jsonUser = JObject.Parse(rez);

                color col = color.none;
                string currentcolor = jsonUser["color"].ToObject<string>();

                switch (currentcolor)
                {
                    case "red":
                        col = color.red;
                        break;
                    case "yellow":
                        col = color.yellow;
                        break;
                    case "green":
                        col = color.green;
                        break;
                        
                }
                
                EconomicModel econ = new EconomicModel();
                econ.yearlySpending = jsonUser["yearlySpending"].ToObject<int>();
                econ.WeeklyPrice = jsonUser["WeeklyPrice"].ToObject<int>();
                econ.savedFromLastWeek = jsonUser["savedFromLastWeek"].ToObject<int>();
                EnviormentModel env = new EnviormentModel();
                env.yearlyKHWSpending = jsonUser["yearlyKHWSpending"].ToObject<int>();
                env.savedKHWFromLastWeek = jsonUser["savedKHWFromLastWeek"].ToObject<int>();
                env.WeeklyKWHUsage = jsonUser["WeeklyKWHUsage"].ToObject<int>();
                ApplicationUser appUser = new ApplicationUser()
                {
                    status = "",
                    Color = col,
                    UserName = user.name,
                    Email = user.email,
                    EconomicModel = econ,
                    EnviormentalStats = env,
                    friends = new List<string>()
                };
                IdentityResult result =  _userManager.CreateAsync(appUser, user.password).GetAwaiter().GetResult();
                if (result.Succeeded)
                    ViewBag.Message = "user creAted succesfully";
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("",error.Description);
                }

            }
            return View(user);

        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result =
                    await _RoleManager.CreateAsync(new ApplicationRole() {Name = userRole.RoleName});
                if (result.Succeeded)
                    ViewBag.Message = "Role Created yyes";
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View();

        }
    }
    
    public class Person
    {

        // field variable
        public string name;
        public string email;

        // member function or method
        public  Person(string param, string email)
        {
            this.name = param;
            this.email = email;
        }
    }
}