using KinoDotNetCore.Models;
using System.Collections.Generic;

namespace KinoDotNetCore.Repositories
{
    public interface IOpinieRepository
    {
        List<Opinie> GetOpinieByMovieID(int filmId);

    }
}
