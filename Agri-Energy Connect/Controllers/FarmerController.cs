using Microsoft.AspNetCore.Mvc;

namespace Agri_Energy_Connect.Controllers
{
    public class FarmerController : Controller
    {

        [HttpGet]
        public IActionResult FarmerDashboard()
        {
            return View();
        }


    }
}
