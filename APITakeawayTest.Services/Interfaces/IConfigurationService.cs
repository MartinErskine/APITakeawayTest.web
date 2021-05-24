using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APITakeawayTest.Services.Helpers;
using APITakeawayTest.Services.Models;

namespace APITakeawayTest.Services.Interfaces
{
    public interface IConfigurationService
    {
        Task<ServiceResponse<List<LaptopModel>>> GetLaptops();
        Task<ServiceResponse<LaptopModel>> GetLaptop(Guid id);
        Task<ServiceResponse<List<ConfigurationItemModel>>> GetConfigurations();
        Task<ServiceResponse<List<ConfiguredLaptopModel>>> GetBasket();
        Task<ServiceResponse<ConfiguredLaptopModel>> PostConfiguredLaptop(ConfiguredLaptopModel configuredLaptopModel);
    }
}