using DesignPatterns.FactoryMethod;
using DesignPatterns.FactoryMethod.PizzaShop;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbClient.FactoryUsageExample();

            PizzaShopFactorySample();
        }

        private static void PizzaShopFactorySample()
        {
            var pizzaShop = new PizzaShop();
            var pizza = pizzaShop.CreateByName("Margherita");
            Console.WriteLine(pizza);
        }
    }
}
