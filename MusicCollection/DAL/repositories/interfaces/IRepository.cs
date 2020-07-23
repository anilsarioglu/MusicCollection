using System.Collections.Generic;

namespace DAL.repositories.interfaces {

    public interface IRepository<T> where T : class // It's a type constraint on T, specifying that it must be a class
    {
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        T Create(T obj);
        T Update(T obj);
        void Delete(int id);
    }
}
