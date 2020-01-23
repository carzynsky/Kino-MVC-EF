using System.Collections.Generic;
using System.Linq;

namespace KinoDotNetCore.Repositories
{
    public interface IKinoGeneric<T> where T : class
    {

        List<T> GetAll();
        IQueryable<T> Get();
        T GetById(int id);
        void DeleteById(int id);
        void Update(T entity);
        void Create(T entity);
        void Save();
    }
}
