using Microsoft.EntityFrameworkCore;
using ppedv.RentABrain.Model.Contracts;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Model
{
    public class RentABrainRepositoryAdapter<T> : IRepository<T> where T : Entity
    {
        private readonly RentABrainContext _context;

        public RentABrainRepositoryAdapter(RentABrainContext context)
        {
            _context = context;
        }

        public RentABrainRepositoryAdapter(string connectionString)
        {
            var options = new DbContextOptionsBuilder<RentABrainContext>()
                .UseSqlServer(connectionString).Options;
            _context = new RentABrainContext(options);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToArray();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }

}
