using KinoDotNetCore.Models;
using KinoDotNetCore.ViewModels;
using System.Linq;

namespace KinoDotNetCore.Repositories
{
    public class PracownicyRepository : KinoGeneric<Pracownicy>, IPracownicyRepository
    {
        private readonly KinoContext _context;
        public PracownicyRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckIfAdmin(LoginDetails employeeLoginDetails)
        {
            var pracownik = _context.Pracownicy.Where(e => e.Login == employeeLoginDetails.Login && e.Haslo == employeeLoginDetails.Haslo).FirstOrDefault();
            if (pracownik == null)
                return false;
            else
            {
                if (pracownik.Admin == "t")
                    return true;
                else
                    return false;
            }
        }

        public bool CheckIfLoginDetailsCorrect(LoginDetails employeeLoginDetails)
        {
            var pracownik = _context.Pracownicy.Where(e => e.Login == employeeLoginDetails.Login && e.Haslo == employeeLoginDetails.Haslo).FirstOrDefault();
            if (pracownik == null)
                return false;
            else
                return true;
        }
    }
}
