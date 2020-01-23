using KinoDotNetCore.Models;
using System.Collections.Generic;

namespace KinoDotNetCore.Repositories
{
    public interface IFilmyRepository
    {
        List<Filmy> GetFilmyForCustomer();
    }
}
