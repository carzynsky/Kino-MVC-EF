using KinoDotNetCore.Models;
using KinoDotNetCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KinoDotNetCore.Controllers
{
    public class FilmiesController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public FilmiesController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            List<Filmy> movies = UnitOfWork.FilmyRepository.GetAll();
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

            if (opinie == null)
            {
                return NotFound();
            }

            return View(opinie);
        }


    }
}
