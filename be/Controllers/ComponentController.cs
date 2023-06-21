using be.DTOs;
using be.Models;
using be.Services.ComponentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be.Controllers
{
    [Route("api/component")]
    [ApiController]
    public class ComponentController : ControllerBase
    {

        private readonly DbJiraCloneContext _context;
        public readonly IComponentService _componentService;
        public ComponentController(DbJiraCloneContext db, IComponentService componentService)
        {
            _context = db;
            _componentService = componentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetElement(int id)
        {
            try
            {
                var data = await _context.Components.FindAsync(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        status = 400,
                        message = "The component doesn't exist in database"
                    });
                }
                return Ok(new
                {
                    status = 200,
                    data,
                    message = "Get component is success!"
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
                var data = await _context.Components.ToListAsync();
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

        //Phần Của Huy
        [HttpGet("GetAllComponent")]
        public ActionResult GetComponentList()
        {
            try
            {
                var componentList = _componentService.GetAllComponent();
                return Ok(componentList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllComponentName")]
        public ActionResult GetComponentNameList()
        {
            try
            {
                var componentNameList = _componentService.GetAllComponentName();
                return Ok(componentNameList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddComponent")]
        public async Task<ActionResult> AddComponent(ComponentInformation addComponent)
        {
            try
            {
                Component componentInformation = new Component();
                componentInformation.ComponentName = addComponent.ComponentName;
                componentInformation.Status = addComponent.Status;
                var result = _componentService.AddComponent(componentInformation);
                return Ok(new
                {
                    message = "Add component success!",
                    status = 200,
                    data = result
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetComponentDetail")]
        public ActionResult GetComponentDetail(int componentId)
        {
            try
            {
                var component = _componentService.GetComponentInformation(componentId);
                if (component == null)
                {
                    return Ok(new
                    {
                        message = "The component doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    return Ok(component);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateComponent/{id}")]
        public ActionResult UpdateProject([FromBody] ComponentInformation component)
        {
            try
            {
                Component updateComponent = new Component();
                updateComponent.ComponentId = component.ComponentId;
                updateComponent.ComponentName = component.ComponentName;
                updateComponent.Status = component.Status;
                _componentService.UpdateComponent(updateComponent);
                var result = _componentService.GetComponentInformation(component.ComponentId);
                return Ok(new
                {
                    message = "Edit component success!",
                    status = 200,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ChangeComponentStatus")]
        public ActionResult ChangeStatus(int componentId, bool status)
        {
            try
            {
                var check = _componentService.GetComponentInformation(componentId);
                if (check == null)
                {
                    return Ok(new
                    {
                        message = "The component doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    check.Status = status;
                    _componentService.ChangeStatus(check);
                    return Ok(new
                    {
                        message = "Edit project success!",
                        status = 200,
                        data = _componentService.GetComponentInformation(componentId)
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
