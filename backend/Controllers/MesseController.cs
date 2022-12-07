using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        [EnableCors("CorsApi")]
        public IActionResult getUsers()
        {

            return Ok(configuration.GetValue<string>("big:huge"));
        }

        [HttpPost("submitCustomer")]
        [EnableCors("CorsApi")]
        public IActionResult submitCustomer([FromBody] Customer customer)
        {
            return Ok(customer);
        }
    }
}
