using Microsoft.AspNetCore.Mvc;

namespace KinoDotNetCore.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}