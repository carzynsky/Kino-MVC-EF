﻿using KinoDotNetCore.Repositories;
using KinoDotNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KinoDotNetCore.Controllers
{
    public class CustomerLoginController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public CustomerLoginController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginDetails customerLoginDetails)
        {
            if (ModelState.IsValid)
            {
                if (UnitOfWork.KlienciRepository.CheckIfLoginDetailsCorrect(customerLoginDetails))
                {
                    CustomerPanelController.LoggedUserId = UnitOfWork.KlienciRepository.GetCustomerIdBasedOnLogin(customerLoginDetails.Login);
                    return RedirectToAction("Index", "CustomerPanel");
                }
                else
                    return RedirectToAction("Index");
            }
            else
                return View(customerLoginDetails);
        }

        //public IActionResult Details()
        //{

        //}
    }
}