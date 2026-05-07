using Microsoft.AspNetCore.Mvc;

namespace FitFinderProject.PL.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminGyms()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminMessages()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminPayments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminSubscriptions()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminUsers()
        {
            return View();
        }

    }
}
