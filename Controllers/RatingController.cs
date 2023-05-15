using System;
using AFSAPIService.Model;
using AFSAPIService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AFSAPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private IRatingRepository ratingRepository;

        public RatingController(IRatingRepository repo)
        {
            ratingRepository = repo;
        }

        // POST api/values
        [HttpPost]
        public Rating Post([FromBody] Rating rating)
        {
            return ratingRepository.AddRating(rating);
        }
    }
}

