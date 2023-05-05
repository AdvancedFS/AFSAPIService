using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AFSAPIService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFSAPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/values
        [HttpGet]
        public List<Project> Get()
        {
            var projects = new List<Project>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("AFSDBCon")))
            {
                var sql = "Select ProjectID,ProjectName, ProjectKey,[STATUS] from tblProject";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var project = new Project()
                    {
                        ProjectID = (int)reader["ProjectID"],
                        ProjectKey = reader["ProjectKey"].ToString(),
                        ProjectName = reader["ProjectName"].ToString(),
                        Status = Convert.ToBoolean(reader["Status"]),
                    };
                    projects.Add(project);
                }
            }
            return  projects;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
       
    }
}

