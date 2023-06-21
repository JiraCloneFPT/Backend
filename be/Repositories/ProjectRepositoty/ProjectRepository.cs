using be.Models;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.IProjectRepositoty
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DbJiraCloneContext _context;

        public ProjectRepository()
        {
            _context = new DbJiraCloneContext();
        }
        public object AddProject(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges(); 
                return project;
            } catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void ChangeStatus(Project project)
        {
            try
            {
                var updateStatusProject = _context.Projects.SingleOrDefault(x => x.ProjectId == project.ProjectId);
                updateStatusProject.Status = project.Status;
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public IList<Project> GetAllProject()
        {
            return _context.Projects.ToList();
        }

        public IList<string> GetAllProjectName()
        {
            var projectNames = (from name in _context.Projects
                               select name.ProjectName).ToList();
            return projectNames;
        }

        public IList<string> GetAllShortName()
        {
            var shortNames = (from name in _context.Projects
                                select name.ShortName).ToList();
            return shortNames;
        }

        public Project GetProjectInformation(int projectId)
        {
            try
            {
                var projectDetail = _context.Projects.SingleOrDefault(x => x.ProjectId == projectId);
                return projectDetail;
            } catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Project UpdateProject(Project project)
        {
            try
            {
                var updateProject = _context.Projects.SingleOrDefault(x => x.ProjectId == project.ProjectId);
                updateProject.ProjectName = project.ProjectName;
                updateProject.ShortName = project.ShortName;
                _context.SaveChanges();
                return updateProject;
            } catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
