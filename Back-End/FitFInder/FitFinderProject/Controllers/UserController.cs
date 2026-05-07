using Microsoft.AspNetCore.Mvc;

namespace FitFinderProject.PL.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserHome()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Payments()
        {
            return View();
        }

        public IActionResult Subscription()
        {
            return View();
        }

        public IActionResult Gyms()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }


    }
}
