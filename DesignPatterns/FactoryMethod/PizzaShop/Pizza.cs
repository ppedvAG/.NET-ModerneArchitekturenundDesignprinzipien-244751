
namespace DesignPatterns.FactoryMethod.PizzaShop
{
    public abstract class Pizza
    {
        private readonly string name;

        public List<PizzaToppings> Toppings { get; } = new List<PizzaToppings>();

        protected Pizza(string name)
        {
            this.name = name;
        }

        // Abgeleitete Klassen koennen virtuelle Methode ueberschreiben,
        // d. h. das Verhalten der Standardimplementierung kann veraendert werden
        public virtual void Bake()
        {
            Console.WriteLine($"{name} in Steinofen backen...");
        }

        public override string ToString()
        {
            return $"{name} with {string.Join(", ", Toppings)}";
        }

        internal void Prepare()
        {
            Console.WriteLine($"{name} vorbereiten...");
        }

        internal void Cut()
        {
            Console.WriteLine($"{name} schneiden...");
        }

        internal void Box()
        {
            Console.WriteLine($"{name} verpacken...");
        }
    }
}
