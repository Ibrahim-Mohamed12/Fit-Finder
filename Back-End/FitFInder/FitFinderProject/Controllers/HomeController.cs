using Microsoft.AspNetCore.Mvc;

namespace FitFinderProject.PL.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult role()
        {
            return View();
        }

        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }
    }
}
