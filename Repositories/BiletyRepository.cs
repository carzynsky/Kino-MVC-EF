using KinoDotNetCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KinoDotNetCore.Repositories
{
    public class BiletyRepository : KinoGeneric<Bilety>, IBiletyRepository
    {
        private readonly KinoContext _context;

        public BiletyRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetStanyBiletow()
        {
            List<string> list = new List<string>()
            {
                "niezapłacony",
                "zapłacony",
                "wykorzystany"
            };

            IEnumerable<SelectListItem> items = list.Select(s => new SelectListItem
            {
                Value = s.ToString(),
                Text = s
            });
            return items;

        }

        public Bilety GetTicketById(int id)
        {
            var ticket = _context.Bilety
                 .Include(s => s.Klient)
                 .Include(s => s.Seans)
                 .FirstOrDefault(m => m.Id == id);
            return ticket;
        }

        public List<Bilety> GetTickets()
        {
            List<Bilety> bilety = _context.Bilety.Include(s => s.Klient).Include(s => s.Seans).ToList();
            return bilety;
        }
    }
}
