using System.Collections.Generic;

namespace Kilimanjaro.Domain.Contract
{
    public interface IRepository<T> where T : class
    {
        void Save(T entity);

        void Delete(T entity);

        IEnumerable<T> ListAll();

        T ListById(string id);
    }
}
