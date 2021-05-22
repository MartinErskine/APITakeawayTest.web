using APITakeawayTest.Data.Domain;
using APITakeawayTest.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace APITakeawayTest.Data
{
    public class LaptopDbContext : DbContext
    {
        public LaptopDbContext(DbContextOptions<LaptopDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<ConfigurationItem> ConfigurationItems { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Ram> Ram { get; set; } 
        public DbSet<Storage> Storage { get; set; }

        public DbSet<ConfiguredLaptop> ConfiguredLaptops { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConfigurationItem>()
                .HasDiscriminator<string>("itemType");


            ConfigurationSeeder.Run(modelBuilder);
        }
    }
}
