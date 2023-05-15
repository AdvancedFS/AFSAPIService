using System;
using System.Data;
using System.Data.SqlClient;
using AFSAPIService.Model;

namespace AFSAPIService.Repository
{
	public class ReportIssueRepository : IReportIssueRepository
	{
        public IConfiguration Configuration { get; }
        public string connectionString;

        public ReportIssueRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:AFSDBCon"];
        }

        public bool AddIssue(ReportIssue issue)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spInsertIssue]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProjectKey", issue.ProjectKey);
                    cmd.Parameters.AddWithValue("@IssueType", issue.IssueType);
                    cmd.Parameters.AddWithValue("@Summary", issue.Summary);
                    cmd.Parameters.AddWithValue("@Description", issue.Description);
                    cmd.Parameters.AddWithValue("@ModuleID", issue.ModuleID);
                    cmd.Parameters.AddWithValue("@IssueImage", issue.ImageString);
                    cmd.Parameters.AddWithValue("@ImageName", issue.ImageName);
                    cmd.Parameters.AddWithValue("@CreatorEmail", issue.UserEmail);

                    // cmd.Parameters.AddWithValue("@ret", ParameterDirection.Output);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    result = true;
                }
                catch (Exception ex)
                {
                    return result;
                }
            }
            return result;
        }

        public IEnumerable<ReportIssue> GetAllIssues()
        {
            throw new NotImplementedException();
        }

        public ReportIssue GetIssuesById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

