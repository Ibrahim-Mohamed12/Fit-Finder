using DAL.Entities;
using FitFinderProject.BLL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitFinderProject.PL.Controllers
{
    [Authorize(Roles = "Owner")]
    public class OwnerController : Controller
    {
        //private readonly IGenericService<Gym> Gym;

        //Rest of the services will be added later as needed
        //because of EL-NOMA
        //public OwnerController(IGenericService<Gym> gym)
        //{
        //    Gym = gym;
        //}

        public IActionResult OwnerDashboard()
        {


            return View();
        }

        public IActionResult MyGyms()
        {
            return View();
        }

        public IActionResult Earnings()
        {
            return View();
        }

        public IActionResult Members()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Plans()
        {
            return View();
        }

    }
}
