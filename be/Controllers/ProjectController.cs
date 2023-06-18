using be.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly DbJiraCloneContext _context;
        public ProjectController(DbJiraCloneContext db)
        {
            _context = db;
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
    }
}
