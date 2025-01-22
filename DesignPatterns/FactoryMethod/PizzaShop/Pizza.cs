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

        public override string ToString()
        {
            return $"{name} with {string.Join(", ", Toppings)}";
        }
    }
}
