using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> Query();

        Task Add(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int id);

        Task<int> SaveChanges();
    }
}
