using KinoDotNetCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace KinoDotNetCore.Repositories
{
    public interface ISeanseRepository
    {
        List<Seanse> GetScreeningsByMovieID(int filmId);
        List<Seanse> GetScreenings();
        Seanse Details(int? id);
        Seanse GetScreeningById(int? screeningId);
        IEnumerable<SelectListItem> GetFilmySelectListItems();
        IEnumerable<SelectListItem> GetSaleSelectListItems();
    }
}
