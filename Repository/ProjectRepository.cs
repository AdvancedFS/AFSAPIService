using System;
using System.Data;
using System.Data.SqlClient;
using AFSAPIService.Model;
using Microsoft.Extensions.Configuration;

namespace AFSAPIService.Repository
{
	public class ProjectRepository : IProjectRepository
	{
        public IConfiguration Configuration { get; }
        public string connectionString;

        public ProjectRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:AFSDBCon"];
        }
       
        public IEnumerable<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spGetProjectDetails]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Project project = new Project();
                        project.ProjectID = Convert.ToInt32(rdr["ProjectID"]);
                        project.ProjectName = rdr["ProjectName"].ToString();
                        project.ProjectKey = rdr["ProjectKey"].ToString();
                        project.Status = Convert.ToBoolean(rdr["Status"]);
                        projects.Add(project);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    projects = null;
                }
            }
            return projects;
        }

        public Project GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public Project AddProject(Project customer)
        {
            throw new NotImplementedException();
        }

        public Project UpdateProject(Project customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

