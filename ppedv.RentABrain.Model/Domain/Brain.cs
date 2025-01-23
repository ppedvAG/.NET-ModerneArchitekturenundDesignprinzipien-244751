namespace ppedv.RentABrain.Model.Domain
{
    public class Brain : Entity
    {
        public double PowerConsumption { get; set; }
        public int OperationsPerMinute { get; set; }
        public string Location { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

}
