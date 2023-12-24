
namespace WebApplication12.Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        void Add (T entity);
        void Update (T entity);
        void Delete (int id);
        IEnumerable<T> GetAll();


    }
}
