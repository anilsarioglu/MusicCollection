using System.Collections.Generic;

namespace BLL.managers.interfaces
{
    public interface IManager<T> where T : class
    {
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        T Create(T obj);
        T Update(T obj);
        void Delete(T obj);
    }
}
