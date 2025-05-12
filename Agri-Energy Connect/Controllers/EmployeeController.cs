using Microsoft.AspNetCore.Mvc;

namespace Agri_Energy_Connect.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeDashboard()
        {
            return View();
        }
    }
}
