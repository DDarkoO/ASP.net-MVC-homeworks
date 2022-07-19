using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DATA_ACCESS
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        int Insert(T entity);
        void Edit(T entity);
        void DeleteById(int id);
        T GetById(int id);
    }
}
