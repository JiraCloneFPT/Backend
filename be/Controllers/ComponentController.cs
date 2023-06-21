using be.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be.Controllers
{
    [Route("api/component")]
    [ApiController]
    public class ComponentController : ControllerBase
    {

        private readonly DbJiraCloneContext _context;
        public ComponentController(DbJiraCloneContext db)
        {
            _context = db;
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
    }
}
