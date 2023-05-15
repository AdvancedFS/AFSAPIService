using System;
using System.Data;
using System.Data.SqlClient;
using AFSAPIService.Model;
using Microsoft.Extensions.Configuration;

namespace AFSAPIService.Repository
{
	public class RatingRepository : IRatingRepository
	{
        public IConfiguration Configuration { get; }
        public string connectionString;

        public RatingRepository(IConfiguration configuration)
		{
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:AFSDBCon"];
        }

        public Rating AddRating(Rating rating)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spInsertRating]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProjectKey", rating.ProjectKey);
                    cmd.Parameters.AddWithValue("@RatedBy", rating.RatedBy);
                    cmd.Parameters.AddWithValue("@Percentage", rating.RatingValue);
                    cmd.Parameters.AddWithValue("@RatingOutOf", rating.RatingOutOf);
                    cmd.Parameters.AddWithValue("@ModuleID", rating.ModuleID);
                    cmd.Parameters.AddWithValue("@Comments", rating.Comments);

                    // cmd.Parameters.AddWithValue("@ret", ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    rating = null;
                }
            }
            return rating;
        }

        public IEnumerable<Rating> GetAllRatings()
        {
            throw new NotImplementedException();
        }

        public Rating GetRatingById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

