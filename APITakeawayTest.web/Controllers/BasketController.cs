using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITakeawayTest.Services.Interfaces;
using APITakeawayTest.Services.Models;

namespace APITakeawayTest.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public BasketController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConfiguredLaptopModel>>> Get()
        {
            var response = await _configurationService.GetBasket();

            if (response.IsError)
            {
                return StatusCode((int)response.ErrorCode, response.ErrorDescription);
            }

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ConfiguredLaptopModel>> Post(ConfiguredLaptopModel configuredLaptopModel)
        {
            var response = await _configurationService.PostConfiguredLaptop(configuredLaptopModel);

            if (response.IsError)
            {
                return StatusCode((int)response.ErrorCode, response.ErrorDescription);
            }

            return Ok(response.Data);
        }
    }
}
