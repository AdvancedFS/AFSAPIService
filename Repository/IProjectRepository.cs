using System;
using AFSAPIService.Model;

namespace AFSAPIService.Repository
{
	public interface IProjectRepository
	{
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
        Project AddProject(Project customer);
        Project UpdateProject(Project customer);
        void DeleteProject(int? id);
    }
}

