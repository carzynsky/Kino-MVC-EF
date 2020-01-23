using KinoDotNetCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace KinoDotNetCore.Repositories
{
    interface IBiletyRepository
    {
        List<Bilety> GetTickets();
        Bilety GetTicketById(int id);
        IEnumerable<SelectListItem> GetStanyBiletow();
    }
}
