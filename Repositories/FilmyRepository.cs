using KinoDotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KinoDotNetCore.Repositories
{
    public class FilmyRepository : KinoGeneric<Filmy>, IFilmyRepository
    {
        private readonly KinoContext _context;
        public FilmyRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public List<Filmy> GetFilmyForCustomer()
        {
            List<Filmy> list = _context.Filmy.Include(s => s.Gatunek).Include(s => s.Ograniczenie).ToList();
            return list;
        }
    }
}
