using KinoDotNetCore.Models;
using KinoDotNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KinoDotNetCore.Controllers
{
    public class BiletyController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public BiletyController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Bilety> list = UnitOfWork.BiletyRepository.GetTickets();
            return View(list);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = UnitOfWork.BiletyRepository.GetTicketById((int)id);
            if (bilet == null)
            {
                return NotFound();
            }
            ViewData["StanBiletu"] = UnitOfWork.BiletyRepository.GetStanyBiletow();
            return View(bilet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, StanBiletu, SeansId, KlientId")] Bilety bilet)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.BiletyRepository.Update(bilet);
                UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
    }
}