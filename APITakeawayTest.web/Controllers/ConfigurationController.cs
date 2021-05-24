using System.Collections.Generic;
using System.Threading.Tasks;
using APITakeawayTest.Services.Interfaces;
using APITakeawayTest.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITakeawayTest.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<object>> Get()
        {
            var response = await _configurationService.GetConfigurations();

            if (response.IsError)
            {
                return StatusCode((int)response.ErrorCode, response.ErrorDescription);
            }

            return Ok(response.Data);
        }


    }
}
