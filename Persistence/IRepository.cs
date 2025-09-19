using dive_deep.Models;

namespace dive_deep.Persistence
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int id);
        List<T> GetAll();
        T? GetById(int id);
        void Update(T entity);
    }
}
