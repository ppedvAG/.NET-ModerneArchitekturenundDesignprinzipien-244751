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

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToArrayAsync();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Add(T item)
        {
            _context.Set<T>().Add(item);
            await SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await GetById(id);
            if (item == null) 
                return false;

            _context.Set<T>().Remove(item);
            await SaveChanges();
            return true;
        }

        public async Task<bool> Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);

                await SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !ItemExists(item.Id);
            }
            return true;
        }

        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        private bool ItemExists(int id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }
    }

}
