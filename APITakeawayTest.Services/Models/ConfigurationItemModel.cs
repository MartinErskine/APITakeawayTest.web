using APITakeawayTest.Data.Enums;
using System;

namespace APITakeawayTest.Services.Models
{
    public class ConfigurationItemModel
    {
        public Guid Id { get; set; }

        //TODO: Get Enum Name.
        public ConfigurationItemName ConfigurationType { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
