using System;
using AFSAPIService.Model;
using Microsoft.AspNetCore.Mvc;

namespace AFSAPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ReviewController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Rating rating)
        {

        }

    }
   
}

