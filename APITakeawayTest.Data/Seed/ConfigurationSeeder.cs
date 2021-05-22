using APITakeawayTest.Data.Domain;
using APITakeawayTest.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace APITakeawayTest.Data.Seed
{
    public static class ConfigurationSeeder
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.HasData(
                    new Laptop
                    {
                        Id = new Guid("9ba0aea2-ec32-4cc9-90a3-a2f70895fdaf"),
                        Name = "Dell",
                        Price = 349.87M
                    },
                    new Laptop
                    {
                        Id = new Guid("ab147a3e-f10f-4be5-a403-b22202aa663b"),
                        Name = "Toshiba",
                        Price = 345.67M
                    },
                    new Laptop
                    {
                        Id = new Guid("d55588ad-52b5-4a36-a071-903be399d62d"),
                        Name = "HP",
                        Price = 456.76M
                    }
                );
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.HasData(
                    new Colour
                    {
                        Id = new Guid("9ba0aea2-ec32-4cc9-90a3-a2f70895fdaf"),
                        ConfigurationName = ConfigurationItemName.Colour,
                        Name = "Red",
                        Price = 50.76M
                    },
                    new Colour
                    {
                        Id = new Guid("b642485c-a867-40ac-b8eb-adcabe5b7302"),
                        ConfigurationName = ConfigurationItemName.Colour,
                        Name = "Blue",
                        Price = 50.76M
                    },
                    new Colour
                    {
                        Id = new Guid("a99ea5e9-2b28-4251-9d0b-fcdc56d4d9cd"),
                        ConfigurationName = ConfigurationItemName.Colour,
                        Name = "Green",
                        Price = 50.76M
                    }
                );
            });

            modelBuilder.Entity<Ram>(entity =>
            {
                entity.HasData(
                    new Ram
                    {
                        Id = new Guid("29bd7c1b-5588-42dc-aef0-6df2c14ac5c0"),
                        ConfigurationName = ConfigurationItemName.Ram,
                        Name = "8GB",
                        Price = 45.67M
                    },
                    new Ram
                    {
                        Id = new Guid("a05ade3b-14af-4be3-ad7f-95ef4d268cdb"),
                        ConfigurationName = ConfigurationItemName.Ram,
                        Name = "16GB",
                        Price = 87.88M
                    },
                    new Ram
                    {
                        Id = new Guid("773774fc-fda5-4946-90fe-b022ff40bd82"),
                        ConfigurationName = ConfigurationItemName.Ram,
                        Name = "32GB",
                        Price = 154.96M
                    }
                );
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasData(
                    new Storage
                    {
                        Id = new Guid("cb03105a-f72f-4fdf-978a-4975fc7884a9"),
                        ConfigurationName = ConfigurationItemName.Storage,
                        Name = "HDD 500GB",
                        Price = 123.34M
                    },
                    new Storage
                    {
                        Id = new Guid("8326ea7b-134d-44ab-aaa6-28ce7c669755"),
                        ConfigurationName = ConfigurationItemName.Storage,
                        Name = "SSD 256GB",
                        Price = 89.00M
                    },
                    new Storage
                    {
                        Id = new Guid("1d2dfd2b-5892-4600-a24d-164dc6023dd4"),
                        ConfigurationName = ConfigurationItemName.Storage,
                        Name = "HDD 1TB",
                        Price = 200.00M
                    },
                    new Storage
                    {
                        Id = new Guid("2178426a-891b-4ec7-8ac7-df851a0cb638"),
                        ConfigurationName = ConfigurationItemName.Storage,
                        Name = "NVMe 1TB",
                        Price = 120.00M
                    }
                );
            });
        }
    }
}
