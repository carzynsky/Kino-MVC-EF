using KinoDotNetCore.Models;
using KinoDotNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KinoDotNetCore.Controllers
{
    public class CustomerPanelController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public static int LoggedUserId { get; set; }

        public CustomerPanelController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Filmy> movies = UnitOfWork.FilmyRepository.GetFilmyForCustomer();
            return View(movies);
        }

        public IActionResult ShowSeanse(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var seanse = UnitOfWork.SeanseRepository.GetScreeningsByMovieID((int)id);

            if (seanse == null)
            {
                return NotFound();
            }

            return View(seanse);
        }

        public IActionResult ShowOpinie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = UnitOfWork.OpinieRepository.GetOpinieByMovieID((int)id);
            var movieTitle = UnitOfWork.FilmyRepository.GetById((int)id).Tytul;

            if (opinie == null)
            {
                return NotFound();
            }

            ViewData["IdFilmu"] = id;
            ViewData["TytulFilmu"] = movieTitle;

            return View(opinie);
        }


        public IActionResult AddOpinion(int? id)
        {
            ViewData["FilmId"] = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOpinion([Bind("Ocena, TrescOpinii, FilmId")] Opinie opinia)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.OpinieRepository.Create(opinia);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View("AddOpinion");
        }


        public IActionResult BuyTicket(int? id)
        {
            Bilety bilet = new Bilety
            {
                StanBiletu = "zapłacony",
                SeansId = (int)id,
                KlientId = LoggedUserId,
                Klient = UnitOfWork.KlienciRepository.GetById(LoggedUserId),
                Seans = UnitOfWork.SeanseRepository.GetById((int)id)
            };

            UnitOfWork.BiletyRepository.Create(bilet);
            UnitOfWork.Save();

            return View(bilet);
        }

    }
}