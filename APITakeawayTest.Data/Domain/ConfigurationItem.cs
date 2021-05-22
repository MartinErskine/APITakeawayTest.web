using System;
using APITakeawayTest.Data.Enums;

namespace APITakeawayTest.Data.Domain
{

    public class ConfigurationItem : IEquatable<ConfigurationItem>
    {
        public Guid Id { get; set; }

        public ConfigurationItemName ConfigurationName { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Equals(ConfigurationItem otherConfigurationItem)
        {
            if (otherConfigurationItem is null)
                return false;

            if (ReferenceEquals(this, otherConfigurationItem))
                return true;

            return Id.Equals(otherConfigurationItem.Id)
                   && ConfigurationName.Equals(otherConfigurationItem.ConfigurationName)
                   && Name.Equals(otherConfigurationItem.Name)
                   && Price.Equals(otherConfigurationItem.Price);

        }
    }
}
