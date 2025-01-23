namespace ppedv.RentABrain.Model.Domain
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }

}
