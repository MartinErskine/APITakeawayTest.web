using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APITakeawayTest.Data;
using APITakeawayTest.Data.Domain;
using APITakeawayTest.Services.Helpers;
using APITakeawayTest.Services.Interfaces;
using APITakeawayTest.Services.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APITakeawayTest.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly LaptopDbContext _context;
        private readonly IMapper _mapper;

        public ConfigurationService(LaptopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<LaptopModel>>> GetLaptops()
        {
            try
            {
                var laptops = await _context.Laptops.OrderBy(o => o.Name).ToListAsync();

                if (!laptops.Any())
                {
                    return new ServiceResponse<List<LaptopModel>>
                    {
                        ErrorCode = HttpStatusCode.NotFound,
                        ErrorDescription = "No laptops found"
                    };
                }

                return new ServiceResponse<List<LaptopModel>>
                {
                    Data = _mapper.Map<List<LaptopModel>>(laptops)
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new ServiceResponse<List<LaptopModel>>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }

        public async Task<ServiceResponse<LaptopModel>> GetLaptop(Guid id)
        {
            try
            {
                var laptop = await _context.Laptops.FirstOrDefaultAsync(f => f.Id == id);

                if (laptop == null)
                {
                    return new ServiceResponse<LaptopModel>
                    {
                        ErrorCode = HttpStatusCode.NotFound,
                        ErrorDescription = "Laptops not found"
                    };
                }

                return new ServiceResponse<LaptopModel>
                {
                    Data = _mapper.Map<LaptopModel>(laptop)
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new ServiceResponse<LaptopModel>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }

        public async Task<ServiceResponse<List<ConfigurationItemModel>>> GetConfigurations()
        {
            try
            {
                var configurations = await _context.ConfigurationItems.ToListAsync();

                if (!configurations.Any())
                {
                    return new ServiceResponse<List<ConfigurationItemModel>>
                    {
                        ErrorCode = HttpStatusCode.NotFound,
                        ErrorDescription = "No configurations found"
                    };
                }

                return new ServiceResponse<List<ConfigurationItemModel>>
                {
                    Data = _mapper.Map<List<ConfigurationItemModel>>(configurations)
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new ServiceResponse<List<ConfigurationItemModel>>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }

        public async Task<ServiceResponse<List<ConfiguredLaptopModel>>> GetBasket()
        {
            try
            {
                var configuredLaptops = await _context.ConfiguredLaptops.ToListAsync();

                if (!configuredLaptops.Any())
                {
                    return new ServiceResponse<List<ConfiguredLaptopModel>>
                    {
                        ErrorCode = HttpStatusCode.NotFound,
                        ErrorDescription = "No Basket Items found"
                    };
                }

                return new ServiceResponse<List<ConfiguredLaptopModel>>
                {
                    Data = _mapper.Map<List<ConfiguredLaptopModel>>(configuredLaptops)
                };

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new ServiceResponse<List<ConfiguredLaptopModel>>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }


        public async Task<ServiceResponse<ConfiguredLaptopModel>> PostConfiguredLaptop(ConfiguredLaptopModel configuredLaptopModel)
        {
            try
            {
                var basketItems = await _context.ConfiguredLaptops.ToListAsync();


                var checkItem = await _context.ConfiguredLaptops
                    .Include(i => i.ConfigurationItems)
                    //.Include(i => i.Laptop)
                    .FirstOrDefaultAsync(f =>
                    f.LaptopId == configuredLaptopModel.Laptop.Id);


                //f.ConfigurationItems.Equals(configuredLaptopModel.ConfigurationItems));

                var entity = _mapper.Map<ConfiguredLaptop>(configuredLaptopModel);

                if (checkItem != null)
                {
                    if (checkItem.LaptopId.Equals(entity.LaptopId) && checkItem.ConfigurationItems.Equals(entity.ConfigurationItems))
                    {

                    }

                    return new ServiceResponse<ConfiguredLaptopModel>
                    {
                        ErrorCode = HttpStatusCode.Conflict,
                        ErrorDescription = "Laptop Brand with same configuration already added to basket"
                    };
                }

                



                _context.Entry(entity).State = EntityState.Added;

                if (await _context.SaveChangesAsync() > 0)
                {
                    return new ServiceResponse<ConfiguredLaptopModel>
                    {
                        Data = configuredLaptopModel
                    };
                }

                return new ServiceResponse<ConfiguredLaptopModel>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new ServiceResponse<ConfiguredLaptopModel>
                {
                    ErrorCode = HttpStatusCode.InternalServerError,
                    ErrorDescription = "Internal Server Error"
                };
            }
        }
    }
}
