using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APITakeawayTest.Data.Domain;
using APITakeawayTest.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace APITakeawayTest.Data.Seed
{
    public class LaptopSeeder
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var context = new LaptopDbContext(serviceProvider.GetRequiredService<DbContextOptions<LaptopDbContext>>()))
            {
                if (context.Laptops.Any())
                {
                    return;
                }
                else
                {
                    context.Laptops.AddRange(
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
                }

                context.SaveChanges();
            }
        }
    }
}
