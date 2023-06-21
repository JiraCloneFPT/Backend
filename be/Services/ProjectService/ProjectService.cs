using be.Models;
using be.Repositories.IProjectRepositoty;

namespace be.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        public IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepo = projectRepository;
        }
        public object AddProject(Project project)
        {
            _projectRepo.AddProject(project);
            return project;
        }

        public void ChangeStatus(Project project)
        {
            _projectRepo.ChangeStatus(project);
        }

        public IList<Project> GetAllProject()
        {
            return _projectRepo.GetAllProject().ToList();
        }

        public IList<string> GetAllProjectName()
        {
            return _projectRepo.GetAllProjectName().ToList();
        }

        public IList<string> GetAllShortName()
        {
            return _projectRepo.GetAllShortName().ToList();
        }

        public Project GetProjectInformation(int projectId)
        {
            return _projectRepo.GetProjectInformation(projectId);
        }

        public Project UpdateProject(Project project)
        {
            _projectRepo.UpdateProject(project);
            Project updateProject = _projectRepo.GetProjectInformation(project.ProjectId);
            return updateProject;

        }
    }
}
