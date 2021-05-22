using System;
using System.Collections.Generic;
using System.Linq;

namespace APITakeawayTest.Data.Domain
{
    public class ConfiguredLaptop
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Laptop Laptop { get; set; }

        public List<ConfigurationItem> ConfigurationItems { get; set; }

        public bool Equals(ConfiguredLaptop otherConfiguredLaptop)
        {
            if (otherConfiguredLaptop is null)
                return false;

            if (ReferenceEquals(this, otherConfiguredLaptop))
                return true;

            foreach (var ConfigurationItem in ConfigurationItems)
            {
                var item = otherConfiguredLaptop.ConfigurationItems.FirstOrDefault(w => w.Id == ConfigurationItem.Id && w.Equals(ConfigurationItem));

                if (item == null)
                {
                    return false;
                }

                if (item.Equals(ConfigurationItem))
                {
                    if (Laptop.Equals(otherConfiguredLaptop.Laptop))
                    {
                        return true;
                    }
                }
            }

            return Laptop.Equals(otherConfiguredLaptop.Laptop)
                   && ConfigurationItems.Equals(otherConfiguredLaptop.ConfigurationItems);
        }
    }
}
