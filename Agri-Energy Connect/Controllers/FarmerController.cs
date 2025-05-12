using Microsoft.AspNetCore.Mvc;

namespace Agri_Energy_Connect.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult FarmerDashboard()
        {
            return View();
        }
    }
}
