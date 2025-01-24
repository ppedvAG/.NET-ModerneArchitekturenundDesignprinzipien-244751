using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> Query();

        void Add(T item);
        void Update(T item);
        void Delete(T item);

        int SaveChanges();
    }
}
