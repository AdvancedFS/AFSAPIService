using System;
using AFSAPIService.Model;
using AFSAPIService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AFSAPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportIssueController : ControllerBase
    {
        private IReportIssueRepository reportIssueRepository;

        public ReportIssueController(IReportIssueRepository repo)
        {
            reportIssueRepository = repo;
        }


        // POST api/values
        [HttpPost]
        public bool Post([FromBody] ReportIssue issue)
        {
            return reportIssueRepository.AddIssue(issue);
        }

    }
    
}

