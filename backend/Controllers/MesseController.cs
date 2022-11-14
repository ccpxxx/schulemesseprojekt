using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Messe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesseController : ControllerBase
    {
        public IConfiguration configuration { get; }

        public MesseController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("getUsers")]
        public IActionResult getUsers()
        {

            return Ok(configuration.GetValue<string>("big:huge"));
        }

        public IActionResult submitCustomer([FromBody] Customer customer)
        {
            return Ok(configuration);
        }
    }
}
