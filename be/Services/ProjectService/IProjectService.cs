using be.Models;

namespace be.Services.ProjectService
{
    public interface IProjectService
    {
        object AddProject(Project project);
        IList<Project> GetAllProject();
        void ChangeStatus(Project project);
        Project UpdateProject(Project project);

        Project GetProjectInformation(int projectId);

        IList<string> GetAllProjectName();

        IList<string> GetAllShortName();

    }
}
