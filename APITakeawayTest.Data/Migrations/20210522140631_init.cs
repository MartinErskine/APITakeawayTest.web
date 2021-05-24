using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APITakeawayTest.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguredLaptops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguredLaptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguredLaptops_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigurationType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConfiguredLaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    itemType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationItem_ConfiguredLaptops_ConfiguredLaptopId",
                        column: x => x.ConfiguredLaptopId,
                        principalTable: "ConfiguredLaptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ConfigurationItem",
                columns: new[] { "Id", "ConfigurationType", "ConfiguredLaptopId", "Name", "Price", "itemType" },
                values: new object[,]
                {
                    { new Guid("9ba0aea2-ec32-4cc9-90a3-a2f70895fdaf"), 3, null, "Red", 50.76m, "Colour" },
                    { new Guid("b642485c-a867-40ac-b8eb-adcabe5b7302"), 3, null, "Blue", 50.76m, "Colour" },
                    { new Guid("a99ea5e9-2b28-4251-9d0b-fcdc56d4d9cd"), 3, null, "Green", 50.76m, "Colour" },
                    { new Guid("29bd7c1b-5588-42dc-aef0-6df2c14ac5c0"), 1, null, "8GB", 45.67m, "Ram" },
                    { new Guid("a05ade3b-14af-4be3-ad7f-95ef4d268cdb"), 1, null, "16GB", 87.88m, "Ram" },
                    { new Guid("773774fc-fda5-4946-90fe-b022ff40bd82"), 1, null, "32GB", 154.96m, "Ram" },
                    { new Guid("cb03105a-f72f-4fdf-978a-4975fc7884a9"), 2, null, "HDD 500GB", 123.34m, "Storage" },
                    { new Guid("8326ea7b-134d-44ab-aaa6-28ce7c669755"), 2, null, "SSD 256GB", 89.00m, "Storage" },
                    { new Guid("1d2dfd2b-5892-4600-a24d-164dc6023dd4"), 2, null, "HDD 1TB", 200.00m, "Storage" },
                    { new Guid("2178426a-891b-4ec7-8ac7-df851a0cb638"), 2, null, "NVMe 1TB", 120.00m, "Storage" }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("9ba0aea2-ec32-4cc9-90a3-a2f70895fdaf"), "Dell", 349.87m },
                    { new Guid("ab147a3e-f10f-4be5-a403-b22202aa663b"), "Toshiba", 345.67m },
                    { new Guid("d55588ad-52b5-4a36-a071-903be399d62d"), "HP", 456.76m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationItem_ConfiguredLaptopId",
                table: "ConfigurationItem",
                column: "ConfiguredLaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguredLaptops_LaptopId",
                table: "ConfiguredLaptops",
                column: "LaptopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationItem");

            migrationBuilder.DropTable(
                name: "ConfiguredLaptops");

            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
