using System;
using AFSAPIService.Model;

namespace AFSAPIService.Repository
{
	public interface IRatingRepository
	{
        IEnumerable<Rating> GetAllRatings();
        Rating GetRatingById(int id);
        Rating AddRating(Rating rating);
    }
}

