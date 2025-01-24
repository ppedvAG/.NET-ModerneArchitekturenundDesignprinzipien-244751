using ppedv.RentABrain.Model.Contracts;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Logic.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> repository;

        // Lose Kopplung: Deshalb referenzieren wir nicht gegen den DbContext
        // sondern verwenden ein sog. Repository Pattern

        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public Product? GetMostExpensiveProduct()
        {
            // GetAll macht einen Select auf die DB und holt die gesamte Tabelle ab, z. B. 5000 Datensaetze
            // Query gibt die Query zurueck und EFCore kann sie zu einem SQL Statement umwandeln, d. h.
            // es wird nur ein Bruchteil der Datensaetze geholt.

            // Allerdings kann es je nach Komplexitaet des Ausdrucks sein, dass das Query nicht als SQL Statement umgewandelt werden kann
            return repository.GetAll()
                .Select(e => new
                {
                    Product = e,
                    TotalCost = e.CostPerHour * (decimal)e.TimeSpan.TotalHours
                })
                .OrderByDescending(e => e.TotalCost)
                .FirstOrDefault()?
                .Product;
        }

        public decimal GetTotalCost(int productId)
        {
            var product = repository.GetById(productId);
            if (product == null)
            {
                return 0;
            }

            return product.CostPerHour * (decimal)product.TimeSpan.TotalHours;
        }
    }
}
