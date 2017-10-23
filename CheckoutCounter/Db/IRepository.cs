using System.Collections.Generic;

namespace CheckoutCounter.Db
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        int Insert(T t);
        int Update(T t);
        void Delete(T t);
    }
}
