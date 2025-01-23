namespace ppedv.RentABrain.Model.Domain
{
    public class Product : Entity
    {
        public TimeSpan TimeSpan { get; set; }
        public decimal CostPerHour { get; set; }
        public string Name { get; set; }
        public List<Brain> Brains { get; set; } = new List<Brain>();
    }

}
