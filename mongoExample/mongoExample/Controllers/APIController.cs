using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mongoExample.Models;
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

    }
}