using ppedv.RentABrain.Model.Contracts;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Logic.Services
{
    public class OrderService
    {
        // Lose Kopplung: Deshalb referenzieren wir nicht gegen den DbContext
        // sondern verwenden ein sog. Repository Pattern

        public OrderService(IRepository<Order> repository)
        {
            
        }
    }
}
