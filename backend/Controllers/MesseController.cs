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
        private IMongoRepo<Customer> rep;
        private string table;

        public MesseController(IConfiguration configuration)
        {
            this.configuration = configuration;
            rep = new MongoRepoImpl("Records");
            table = "Customer";
        }

        [HttpGet("getUsers")]
        [EnableCors("CorsApi")]
        public IActionResult getUsers()
        {
            return Ok(rep.getAllFromDb(this.table));
        }

        [HttpPost("submitCustomer")]
        [EnableCors("CorsApi")]
        public IActionResult submitCustomer([FromBody] Customer customer)
        {
            rep.saveCustomer(this.table, customer);
            return Ok();
        }
        [HttpGet("getSpecificUser")]
        [EnableCors("CorsApi")]
        public IActionResult getSpecificUser()
        {
           return Ok();
        }
    }
}