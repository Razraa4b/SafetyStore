using Microsoft.AspNetCore.Mvc;

namespace SafetyStore.Web.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Team()
        {
            return View();
        }

        public IActionResult License()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
