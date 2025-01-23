using System.ComponentModel.DataAnnotations;

namespace ppedv.RentABrain.Model.Domain
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
