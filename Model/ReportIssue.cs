using System;
namespace AFSAPIService.Model
{
	public class ReportIssue
	{
        public string ProjectKey { get; set; }
        public string IssueType { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public long ModuleID { get; set; }
        public string UserEmail { get; set; }
        public string ImageString { get; set; }
        public string ImageName { get; set; }   
    }
}

