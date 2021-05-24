using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace APITakeawayTest.Data.Domain
{
    [Table("ConfiguredLaptops")]
    public class ConfiguredLaptop
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("LaptopFk")]
        public Guid LaptopId { get; set; }

        public Laptop Laptop { get; set; }

        public HashSet<ConfigurationItem> ConfigurationItems { get; set; }

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
                    if (LaptopId.Equals(otherConfiguredLaptop.LaptopId))
                    {
                        return true;
                    }
                }
            }

            return LaptopId.Equals(otherConfiguredLaptop.LaptopId)
                   && ConfigurationItems.Equals(otherConfiguredLaptop.ConfigurationItems);
        }
    }
}
