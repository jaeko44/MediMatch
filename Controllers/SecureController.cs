using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediMatchRMIT.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Secure")]
    public class SecureController : Controller
    {
        // GET: api/Secure
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var Username = User.Identity.Name;
            var isAuthenticated = User.Identity.IsAuthenticated;
            return new string[] { "You", "succesfully authorized" };
        }

        // GET: api/Secure/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Secure
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Secure/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
