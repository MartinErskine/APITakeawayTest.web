using System.Collections.Generic;
using APITakeawayTest.Data.Domain;

namespace APITakeawayTest.Services.Models
{
    public class ConfiguredLaptopModel
    {
        public Laptop Laptop { get; set; }
        public List<ConfigurationItem> ConfigurationItems { get; set; }

    }
}
