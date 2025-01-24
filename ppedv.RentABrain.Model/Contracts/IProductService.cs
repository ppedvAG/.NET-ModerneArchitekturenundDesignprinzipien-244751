using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Model.Contracts
{
    public interface IProductService
    {
        Product? GetMostExpensiveProduct();
        decimal GetTotalCost(int productId);
    }
}