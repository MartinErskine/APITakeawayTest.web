using System;
using System.Collections.Generic;
using System.Linq;
using APITakeawayTest.Data.Domain;

namespace APITakeawayTest.Services.Models
{
    public class ConfiguredLaptopModel
    {
        public Laptop Laptop { get; set; }

        public List<ConfigurationItem> ConfigurationItems { get; set; }

        public bool Equals(ConfiguredLaptopModel otherConfiguredLaptopModel)
        {
            if (otherConfiguredLaptopModel is null)
                return false;

            if (ReferenceEquals(this, otherConfiguredLaptopModel))
                return true;

            foreach (var ConfigurationItem in ConfigurationItems)
            {
                var item = otherConfiguredLaptopModel.ConfigurationItems.FirstOrDefault(w => w.Id == ConfigurationItem.Id && w.Equals(ConfigurationItem));

                if (item == null)
                {
                    return false;
                }

                if (item.Equals(ConfigurationItem))
                {
                    if (Laptop.Equals(otherConfiguredLaptopModel.Laptop))
                    {
                        return true;
                    }
                }
            }

            return Laptop.Equals(otherConfiguredLaptopModel.Laptop)
                   && ConfigurationItems.Equals(otherConfiguredLaptopModel.ConfigurationItems);
        }
    }
}
