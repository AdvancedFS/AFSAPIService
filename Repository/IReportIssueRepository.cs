using System;
using AFSAPIService.Model;

namespace AFSAPIService.Repository
{
	public interface IReportIssueRepository
	{
        IEnumerable<ReportIssue> GetAllIssues();
        ReportIssue GetIssuesById(int id);
        bool AddIssue(ReportIssue issue);
    }
}

