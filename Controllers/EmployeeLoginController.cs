using KinoDotNetCore.Repositories;
using KinoDotNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KinoDotNetCore.Controllers
{
    public class EmployeeLoginController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public EmployeeLoginController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginDetails employeeLoginDetails)
        {
            if (ModelState.IsValid)
            {
                if (UnitOfWork.PracownicyRepository.CheckIfLoginDetailsCorrect(employeeLoginDetails))
                {
                    if (UnitOfWork.PracownicyRepository.CheckIfAdmin(employeeLoginDetails))
                        return RedirectToAction("Index", "AdminPanel");
                    else
                        return RedirectToAction("Index", "EmployeePanel");
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
                return View(employeeLoginDetails);

        }
    }
}