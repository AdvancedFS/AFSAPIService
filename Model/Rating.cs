using System;
namespace AFSAPIService.Model
{
	public class Rating
	{
        public string ProjectKey { get; set; }
        public string RatedBy { get; set; }
        public int RatingValue { get; set; }
        public int RatingOutOf { get; set; }
        public long ModuleID { get; set; }
        public string Comments { get; set; }
    }
}

