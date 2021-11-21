using System;
using System.Collections.Generic;
using System.Linq;
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
    public class APIController : Controller
    {
        
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _RoleManager;
        public APIController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._RoleManager = roleManager;
        }
        // name is actually email
        public  string GetUser(string name)
        {   

            ApplicationUser usr = _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult();
            
            
            // normalize email:
            string normalizedEmail =  _userManager.NormalizeEmail(name);
            
            if (_userManager.FindByEmailAsync(normalizedEmail).GetAwaiter().GetResult() != null)
            {
                

                if (usr != null)
                {
                    if (usr.friends.Contains(normalizedEmail))
                    {
                        return "already";
                    } else if (usr.friends != null)
                    {
                        usr.friends.Add(normalizedEmail);
                    }
                    else
                    {
                        usr.friends = new List<string>() {normalizedEmail};
                    }

                    _userManager.UpdateAsync(usr).GetAwaiter().GetResult();
                }

                return "true";
            }
            return "false";
        }

        private string hashUserEmail()
        {
            ApplicationUser usr =   _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult();
            string  name = usr.UserName;
            string email = usr.Email;
            string UserEmail = name + email;
            string hash = "";
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(UserEmail);
                byte[] hashBytes = sha.ComputeHash(textBytes);
        
                // Convert back to a string, removing the '-' that BitConverter adds
                hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty).ToLower();

            }

            return hash;
        }

        private string updateAndgetNewuser()
        {
            var hass = new hashContainer(hashUserEmail());
            var json = JsonConvert.SerializeObject(hass);
            
            // getting user info from api
            string rez = "";
            try
            {
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://127.0.0.1:9999/updateuser";
                using var client = new HttpClient();
                var response = client.PostAsync(url, data).GetAwaiter().GetResult();

                rez = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                Content("error accessing watts api, maybe turn it on?");
            }

            return rez;
        }
        public  IActionResult Updateuser()
        {
            string stringUsr = updateAndgetNewuser();

            var cuurrentusr = _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult();

            JObject jsonUser = JObject.Parse(stringUsr);
            
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
            
            cuurrentusr.EconomicModel.yearlySpending = jsonUser["yearlySpending"].ToObject<int>();
            cuurrentusr.EconomicModel.WeeklyPrice = jsonUser["WeeklyPrice"].ToObject<int>();
            cuurrentusr.EconomicModel.savedFromLastWeek = jsonUser["savedFromLastWeek"].ToObject<int>();
       
            cuurrentusr.EnviormentalStats.yearlyKHWSpending = jsonUser["yearlyKHWSpending"].ToObject<int>();
            cuurrentusr.EnviormentalStats.savedKHWFromLastWeek = jsonUser["savedKHWFromLastWeek"].ToObject<int>();
            cuurrentusr.EnviormentalStats.WeeklyKWHUsage = jsonUser["WeeklyKWHUsage"].ToObject<int>();
            
            _userManager.UpdateAsync(cuurrentusr).GetAwaiter().GetResult();
             return RedirectToAction("index", "Home");
        }
           
        }


    public class hashContainer
    {
        public string hash { get; set; }

        public hashContainer(string s)
        {
            this.hash = s;
        }



    }
}