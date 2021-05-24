using System;
using System.ComponentModel.DataAnnotations.Schema;
using APITakeawayTest.Data.Enums;

namespace APITakeawayTest.Data.Domain
{
    [Table("ConfigurationItem")]
    public class ConfigurationItem : IEquatable<ConfigurationItem>
    {
        public Guid Id { get; set; }

        public ConfigurationItemName ConfigurationType { get; set; }

        //[ForeignKey("LaptopFk")]
        //public Guid LaptopId { get; set; }
        //public Laptop Laptop { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Equals(ConfigurationItem otherConfigurationItem)
        {
            if (otherConfigurationItem is null)
                return false;

            if (ReferenceEquals(this, otherConfigurationItem))
                return true;

            return Id.Equals(otherConfigurationItem.Id)
                   && ConfigurationType.Equals(otherConfigurationItem.ConfigurationType)
                   && Name.Equals(otherConfigurationItem.Name)
                   && Price.Equals(otherConfigurationItem.Price);

        }
    }
}
