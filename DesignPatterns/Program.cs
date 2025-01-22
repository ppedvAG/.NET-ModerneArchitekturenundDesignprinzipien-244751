using DesignPatterns.BuilderPattern;
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

            PizzaConfiguratorSample();
        }

        private static void PizzaShopFactorySample()
        {
            Console.WriteLine("\nFactory Pattern demonstrieren");

            var pizzaShop = new PizzaShop();
            var pizza = pizzaShop.CreateByName("Margherita");
            Console.WriteLine(pizza);
        }

        private static void PizzaConfiguratorSample()
        {
            Console.WriteLine("\nBuilder Pattern demonstrieren");
            
            var builder = new PizzaConfigurator();
            var pizza = builder
                .AddPepperoni()
                .AddCheese()
                .AddSalami()
                .Build();
            Console.WriteLine("Own Pizza with selected toppings:");
            Console.WriteLine(pizza);
        }
    }
}
