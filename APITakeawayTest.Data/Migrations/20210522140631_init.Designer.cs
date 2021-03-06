// <auto-generated />
using System;
using APITakeawayTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APITakeawayTest.Data.Migrations
{
    [DbContext(typeof(LaptopDbContext))]
    [Migration("20210522140631_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APITakeawayTest.Data.Domain.ConfigurationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ConfigurationType")
                        .HasColumnType("int");

                    b.Property<Guid?>("ConfiguredLaptopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("itemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfiguredLaptopId");

                    b.ToTable("ConfigurationItem");

                    b.HasDiscriminator<string>("itemType").HasValue("ConfigurationItem");
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.ConfiguredLaptop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LaptopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LaptopId");

                    b.ToTable("ConfiguredLaptops");
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.Laptop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Laptops");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ba0aea2-ec32-4cc9-90a3-a2f70895fdaf"),
                            Name = "Dell",
                            Price = 349.87m
                        },
                        new
                        {
                            Id = new Guid("ab147a3e-f10f-4be5-a403-b22202aa663b"),
                            Name = "Toshiba",
                            Price = 345.67m
                        },
                        new
                        {
                            Id = new Guid("d55588ad-52b5-4a36-a071-903be399d62d"),
                            Name = "HP",
                            Price = 456.76m
                        });
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.Colour", b =>
                {
                    b.HasBaseType("APITakeawayTest.Data.Domain.ConfigurationItem");

                    b.ToTable("ConfigurationItem");

                    b.HasDiscriminator().HasValue("Colour");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ba0aea2-ec32-4cc9-90a3-a2f70895fdaf"),
                            ConfigurationType = 3,
                            Name = "Red",
                            Price = 50.76m
                        },
                        new
                        {
                            Id = new Guid("b642485c-a867-40ac-b8eb-adcabe5b7302"),
                            ConfigurationType = 3,
                            Name = "Blue",
                            Price = 50.76m
                        },
                        new
                        {
                            Id = new Guid("a99ea5e9-2b28-4251-9d0b-fcdc56d4d9cd"),
                            ConfigurationType = 3,
                            Name = "Green",
                            Price = 50.76m
                        });
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.Ram", b =>
                {
                    b.HasBaseType("APITakeawayTest.Data.Domain.ConfigurationItem");

                    b.ToTable("ConfigurationItem");

                    b.HasDiscriminator().HasValue("Ram");

                    b.HasData(
                        new
                        {
                            Id = new Guid("29bd7c1b-5588-42dc-aef0-6df2c14ac5c0"),
                            ConfigurationType = 1,
                            Name = "8GB",
                            Price = 45.67m
                        },
                        new
                        {
                            Id = new Guid("a05ade3b-14af-4be3-ad7f-95ef4d268cdb"),
                            ConfigurationType = 1,
                            Name = "16GB",
                            Price = 87.88m
                        },
                        new
                        {
                            Id = new Guid("773774fc-fda5-4946-90fe-b022ff40bd82"),
                            ConfigurationType = 1,
                            Name = "32GB",
                            Price = 154.96m
                        });
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.Storage", b =>
                {
                    b.HasBaseType("APITakeawayTest.Data.Domain.ConfigurationItem");

                    b.ToTable("ConfigurationItem");

                    b.HasDiscriminator().HasValue("Storage");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cb03105a-f72f-4fdf-978a-4975fc7884a9"),
                            ConfigurationType = 2,
                            Name = "HDD 500GB",
                            Price = 123.34m
                        },
                        new
                        {
                            Id = new Guid("8326ea7b-134d-44ab-aaa6-28ce7c669755"),
                            ConfigurationType = 2,
                            Name = "SSD 256GB",
                            Price = 89.00m
                        },
                        new
                        {
                            Id = new Guid("1d2dfd2b-5892-4600-a24d-164dc6023dd4"),
                            ConfigurationType = 2,
                            Name = "HDD 1TB",
                            Price = 200.00m
                        },
                        new
                        {
                            Id = new Guid("2178426a-891b-4ec7-8ac7-df851a0cb638"),
                            ConfigurationType = 2,
                            Name = "NVMe 1TB",
                            Price = 120.00m
                        });
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.ConfigurationItem", b =>
                {
                    b.HasOne("APITakeawayTest.Data.Domain.ConfiguredLaptop", null)
                        .WithMany("ConfigurationItems")
                        .HasForeignKey("ConfiguredLaptopId");
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.ConfiguredLaptop", b =>
                {
                    b.HasOne("APITakeawayTest.Data.Domain.Laptop", "Laptop")
                        .WithMany()
                        .HasForeignKey("LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop");
                });

            modelBuilder.Entity("APITakeawayTest.Data.Domain.ConfiguredLaptop", b =>
                {
                    b.Navigation("ConfigurationItems");
                });
#pragma warning restore 612, 618
        }
    }
}
