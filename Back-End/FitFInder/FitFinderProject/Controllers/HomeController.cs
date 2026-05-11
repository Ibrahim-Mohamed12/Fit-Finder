using DAL.Entities;
using FitFinderProject.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace FitFinderProject.PL.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }



        [HttpGet]
        public IActionResult index()
        {
            return View();
        }

        #region Login
        [HttpGet]
        public IActionResult login(string role = "")
        {
            if (role == "T")
            {
                TempData["Role"] = "Trainee";

            }
            else if (role == "G")
            {
                TempData["Role"] = "Owner";
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var role = await userManager.GetRolesAsync(user);

                    if ((TempData["Role"]?.ToString() == "Trainee" && role.Contains("Trainee")) ||
                        (TempData["Role"]?.ToString() == "Owner" && role.Contains("Owner"))
                        || role.Contains("Admin"))
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                        if (result.Succeeded)
                        {
                           if(role.Contains("Trainee"))
                            {
                                return RedirectToAction("UserHome", "User");
                            }
                            else if (role.Contains("Owner"))
                            {
                                return RedirectToAction("OwnerDashboard", "Owner");
                            }
                           else if(role.Contains("Admin"))
                            {
                                return RedirectToAction("AdminDashboard", "Admin");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You do not have the required role to log in.");
                        return View(model);
                    }
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

        #endregion
        [HttpGet]
        public IActionResult role()
        {
            return View();
        }

        #region SignUp
        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> signup(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser User = model.ToUser();

                IdentityResult result =
                    await userManager.CreateAsync(User, model.Password);

                if (result.Succeeded)
                {
                    if ((string?)TempData["Role"] == "Trainee")
                    {
                        var test = await userManager.AddToRoleAsync(User, "Trainee");
                    }
                    else if ((string?)TempData["Role"] == "Owner")
                    {
                        var test = await userManager.AddToRoleAsync(User, "Owner");
                    }

                    await signInManager.SignInAsync(User, false);
                    return RedirectToAction("login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        #endregion
            
            [HttpGet]
            public async Task<IActionResult> logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("index");
            }
    }
}
