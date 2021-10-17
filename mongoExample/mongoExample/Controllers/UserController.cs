using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mongoExample.Models;

namespace mongoExample.Controllers
{
    public class UserController : Controller
    {
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
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = user.name,
                    Email = user.email
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, user.password);
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
}