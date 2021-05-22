using System;
using APITakeawayTest.Data.Domain;
using APITakeawayTest.Data.Enums;

namespace APITakeawayTest.Test
{
    public static class ConfiguredLaptops
    {
        public static ConfiguredLaptop ConfiguredLaptop { get; set; }
        public static ConfiguredLaptop ConfiguredLaptopSame { get; set; }
        public static ConfiguredLaptop ConfiguredLaptopDifferent { get; set; }


        public static void Initialise()
        {
            ConfiguredLaptop = new ConfiguredLaptop
            {
                Laptop = new Laptop
                {
                    Id = new Guid("a99a8e22-52f7-4f53-b443-ec2519cd34df"),
                    Name = "DELL XPS 13",
                    Price = 350.00M
                }
            };

            var ram = new Ram
            {
                Id = new Guid("6912564b-5052-47b2-8e2d-f90e5e556556"),
                ConfigurationName = ConfigurationItemName.Ram,
                Name = "1GB",
                Price = 65.00M
            };
            var colour = new Colour
            {
                Id = new Guid("34ee3871-7b6f-464a-ba3e-3dd3197ca69e"),
                ConfigurationName = ConfigurationItemName.Colour,
                Name = "Red",
                Price = 30.00M
            };
            //TODO: Create List of Storage devices.
            var storage = new Storage
            {
                ConfigurationName = ConfigurationItemName.Storage,
                Id = new Guid("ea634923-7e35-449d-8c8b-1d7b17865a9b"),
                Name = "256GB SSD",
                Price = 120.00M
            };

            ConfiguredLaptop.ConfigurationItems.Add(ram);
            ConfiguredLaptop.ConfigurationItems.Add(ram);
            ConfiguredLaptop.ConfigurationItems.Add(ram);

            ConfiguredLaptopSame = new ConfiguredLaptop
            {
                Laptop = new Laptop
                {
                    Id = new Guid("a99a8e22-52f7-4f53-b443-ec2519cd34df"),
                    Name = "DELL XPS 13",
                    Price = 350.00M
                }
            };

            ram = new Ram
            {
                Id = new Guid("6912564b-5052-47b2-8e2d-f90e5e556556"),
                ConfigurationName = ConfigurationItemName.Ram,
                Name = "1GB",
                Price = 65.00M
            };
            colour = new Colour
            {
                Id = new Guid("34ee3871-7b6f-464a-ba3e-3dd3197ca69e"),
                ConfigurationName = ConfigurationItemName.Colour,
                Name = "Red",
                Price = 30.00M
            };
            storage = new Storage
            {
                ConfigurationName = ConfigurationItemName.Storage,
                Id = new Guid("ea634923-7e35-449d-8c8b-1d7b17865a9b"),
                Name = "256GB SSD",
                Price = 120.00M
            };

            ConfiguredLaptopSame.ConfigurationItems.Add(ram);
            ConfiguredLaptopSame.ConfigurationItems.Add(ram);
            ConfiguredLaptopSame.ConfigurationItems.Add(ram);

            ConfiguredLaptopDifferent = new ConfiguredLaptop
            {
                Laptop = new Laptop
                {
                    Id = new Guid("a99a8e22-52f7-4f53-b443-ec2519cd34df"),
                    Name = "DELL XPS 15",
                    Price = 350.00M
                }
            };

            ram = new Ram
            {
                Id = new Guid("6912564b-5052-47b2-8e2d-f90e5e556556"),
                ConfigurationName = ConfigurationItemName.Ram,
                Name = "1GB",
                Price = 65.00M
            };
            colour = new Colour
            {
                Id = new Guid("34ee3871-7b6f-464a-ba3e-3dd3197ca69e"),
                ConfigurationName = ConfigurationItemName.Colour,
                Name = "Red",
                Price = 30.00M
            };
            storage = new Storage
            {
                ConfigurationName = ConfigurationItemName.Storage,
                Id = new Guid("ea634923-7e35-449d-8c8b-1d7b17865a9b"),
                Name = "256GB SSD",
                Price = 120.00M
            };

            ConfiguredLaptopDifferent.ConfigurationItems.Add(ram);
            ConfiguredLaptopDifferent.ConfigurationItems.Add(ram);
            ConfiguredLaptopDifferent.ConfigurationItems.Add(ram);
        }
    }
}
