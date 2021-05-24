using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITakeawayTest.Data.Domain
{
    [Table("Laptops")]
    public class Laptop
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        //[ForeignKey("ConfigurationItemFk")]
        //public Guid ConfigurationItemId { get; set; }
        //public ConfigurationItem ConfigurationItem { get; set; }

        public bool Equals(Laptop otherLaptop)
        {
            if (otherLaptop is null)
                return false;

            if (ReferenceEquals(this, otherLaptop))
                return true;

            return Id.Equals(otherLaptop.Id)
                   && Name.Equals(otherLaptop.Name)
                   && Price.Equals(otherLaptop.Price);
        }
    }
}
