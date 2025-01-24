using Microsoft.EntityFrameworkCore;
using ppedv.RentABrain.Model;

namespace ppedv.RentABrain.DataAccess.Tests
{
    public class TestDatabase : IDisposable
    {
        private const string ConnectionString = "Data Source=(localdb)\\SWArch250123;Initial Catalog=RentABrainUnitTests;Integrated Security=True;TrustServerCertificate=False";

        private static readonly object _lock = new();
        private static bool _dbCreated = false;
        private RentABrainContext? _context;

        public TestDatabase()
        {
            // Tests werden parallel ausgefuehrt weshalb hier ein Lock benoetigt wird
            lock (_lock)
            {
                if (!_dbCreated)
                {
                    using var context = CreateContext();

                    context.Database.EnsureDeleted();

                    //context.Database.EnsureCreated();
                    context.Database.Migrate(); // erzeugt und fuehrt migration script aus

                    _dbCreated = true;
                }
            }
        }

        public void Dispose()
        {
            using var context = GetContext();
            //context.Database.EnsureDeleted();
            context.Dispose();
        }

        // Compound assignment (??=): Initialisiere bei erster Verwendung
        public RentABrainContext GetContext() => _context ??= CreateContext();

        public RentABrainContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<RentABrainContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new RentABrainContext(options);
        }
    }

}