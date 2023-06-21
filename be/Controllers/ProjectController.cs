using be.DTOs;
using be.Models;
using be.Services.ProjectService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public readonly IProjectService _projectService;
        private readonly DbJiraCloneContext _context;
        public ProjectController(DbJiraCloneContext db, IProjectService projectService)
        {
            _context = db;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult> GetElement(int id)
        {
            try
            {
                var data = await _context.Projects.FindAsync(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        status = 400,
                        message = "The project doesn't exist in database"
                    });
                }
                return Ok(new
                {
                    status = 200,
                    data,
                    message = "Get project is success!"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("all")]
        public async Task<ActionResult> GetElements()
        {
            try
            {
                var data = await _context.Projects.ToListAsync();
                return Ok(new
                {
                    status = 200,
                    data
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        //Phần của Huy

        [HttpGet("GetAllProject")]
        public ActionResult GetProjectList()
        {
            try
            {
                var projectList = _projectService.GetAllProject();
                return Ok(projectList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllProjectName")]
        public ActionResult GetProjectNames()
        {
            try
            {
                var projectNames = _projectService.GetAllProjectName();
                return Ok(projectNames);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllShortName")]
        public ActionResult GetAllShortName()
        {
            try
            {
                var shortNames = _projectService.GetAllShortName();
                return Ok(shortNames);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddProject")]
        public async Task<ActionResult> AddProject(ProjectInformation addProject)
        {
            try
            {
                Project projectInformation = new Project();
                projectInformation.ProjectName = addProject.ProjectName;
                projectInformation.ShortName = addProject.ShortName;
                projectInformation.Status = addProject.Status;
                var result = _projectService.AddProject(projectInformation);
                return Ok(new
                {
                    message = "Add project success!",
                    status = 200,
                    data = result
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetProjectDetail")]
        public ActionResult GetProjectDetail(int projectId)
        {
            try
            {
                var project = _projectService.GetProjectInformation(projectId);
                if (project == null)
                {
                    return Ok(new
                    {
                        message = "The project doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    return Ok(project);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateProject/{id}")]
        public ActionResult UpdateProject([FromBody] ProjectInformation project)
        {
            try
            {
                Project updateProject = new Project();
                updateProject.ProjectId = project.ProjectId;
                updateProject.ProjectName = project.ProjectName;
                updateProject.ShortName = project.ShortName;
                updateProject.Status = project.Status;
                _projectService.UpdateProject(updateProject);
                var result = _projectService.GetProjectInformation(project.ProjectId);
                return Ok(new
                {
                    message = "Edit project success!",
                    status = 200,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ChangeProjectStatus")]
        public ActionResult ChangeStatus(int projectId, bool status)
        {
            try
            {
                var check = _projectService.GetProjectInformation(projectId);
                if (check == null)
                {
                    return Ok(new
                    {
                        message = "The project doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    check.Status = status;
                    _projectService.ChangeStatus(check);
                    return Ok(new
                    {
                        message = "Edit project success!",
                        status = 200,
                        data = _projectService.GetProjectInformation(projectId)
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
