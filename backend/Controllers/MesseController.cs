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
            rep = new MongoRepoImpl(configuration.GetValue<string>("mongoServerDetails:database"));
            table = configuration.GetValue<string>("mongoServerDetails:table");
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
        [HttpGet("getCompanyCustomers")]
        [EnableCors("CorsApi")]
        public IActionResult getCompanyCustomers()
        {
         return Ok(rep.getCompanyCustomers(table));
        }
    }
}