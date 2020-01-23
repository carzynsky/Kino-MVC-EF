using Microsoft.AspNetCore.Mvc;

namespace KinoDotNetCore.Controllers
{
    public class EmployeePanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}