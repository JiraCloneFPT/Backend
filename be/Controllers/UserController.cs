using be.Models;
using be.Services.OtherService;
using be.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly EmailService _emailService; 

        public UserController()
        {
            _userService= new UserService();
            _emailService = new EmailService();
        }

        [HttpGet("all")]
        public ActionResult GetAllUsers()
        {
            var result = _userService.GetAllUser();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    
        [HttpPost("upload2")]
        public async Task<ActionResult> GetDataUsers2([FromBody] IList<IList<string>> record)
        {
            User user = null;
            IList<Comment> comment = new List<Comment>(); 
            for (int i = 1; i < record.Count; i++)
            {
                user = new User();
                user.FullName = record[i][0];
                user.Birthday = DateTime.Parse( record[i][1]);
                user.Email = record[i][2];
                user.Password = _userService.GenerateRandomString();
                var account = _userService.GenerateAccount(_userService.ReplaceVietnameseCharacters(record[i][0]));
                user.AccountName = account;
                user.Status = "";
                user.Comments = (ICollection<Comment>)comment;
                user.RoleId = 1;

                //await Task.Run(() => _userService.AddUser(user));
                //await _userService.AddUser(user);
                _emailService.SendMail(user.Email, 2, user.FullName, user.AccountName, user.Password);
            }

            return Ok();
        }

        [HttpPost("upload")]
        public  ActionResult GetDataUsers([FromBody] IList<IList<string>> record)
        {
            User user = null;
            IList<Comment> comment = new List<Comment>();
            for (int i = 1; i < record.Count; i++)
            {
                user = new User();
                user.FullName = record[i][0];
                user.Birthday = DateTime.Parse(record[i][1]);
                user.Email = record[i][2];
                user.Password = _userService.GenerateRandomString();
                var account = _userService.GenerateAccount(_userService.ReplaceVietnameseCharacters(record[i][0]));
                user.AccountName = account;
                user.Status = "";
                user.Comments = (ICollection<Comment>)comment;
                user.RoleId = 1;

                //await Task.Run(() => _userService.AddUser(user));
                //_userService.AddUser(user);
                _emailService.SendMail(user.Email, 2, user.FullName, user.AccountName, user.Password);
            }

            return Ok();
        }


    }
}
