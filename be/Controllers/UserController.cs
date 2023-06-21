using be.Models;
using be.Services.OtherService;
using be.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using be.DTOs;

namespace be.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        private readonly EmailService _emailService;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _userService = new UserService();
            _emailService = new EmailService();
            _configuration = configuration;
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

                await Task.Run(() => _userService.AddUser(user));
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
                _userService.AddUser(user);
                _emailService.SendMail(user.Email, 2, user.FullName, user.AccountName, user.Password);
            }

            return Ok();
        }

        //Phan Cua Huy

        [HttpGet("GetAllUser")]
        public ActionResult GetUserList()
        {
            try
            {
                var userList = _userService.GetAllUser();
                return Ok(userList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(AddUser adduser)
        {
            try
            {
                User user = new User();
                user.FullName = adduser.Fullname;
                user.Email = adduser.Email;
                user.Birthday = adduser.BirthDay;
                var result = _userService.AddUser(user);
                return Ok(new
                {
                    message = "Add user success!",
                    status = 200,
                    data = result
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetUserDetail")]
        public ActionResult GetUserDetail(int userId)
        {
            try
            {
                var user = _userService.GetUserInformation(userId);
                if (user == null)
                {
                    return Ok(new
                    {
                        message = "The user doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateUser/{id}")]
        public ActionResult UpdateUser([FromBody] UserUpdateInfor user)
        {
            try
            {
                User updateUser = new User();
                updateUser.UserId = user.UserId;
                updateUser.FullName = user.Fullname;
                updateUser.Email = user.Email;
                updateUser.Password = user.Password;
                updateUser.Birthday = user.BirthDay;
                var afterUpdate = _userService.UpdateUser(updateUser);
                return Ok(new
                {
                    message = "Edit user success!",
                    status = 200,
                    data = afterUpdate
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ChangeUserStatus")]
        public ActionResult ChangeStatus(int userId, string status)
        {
            try
            {
                var check = _userService.GetUserInformation(userId);
                if (check == null)
                {
                    return Ok(new
                    {
                        message = "The user doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    User updateUser = new User();
                    updateUser.UserId = userId;
                    updateUser.Status = status;
                    _userService.ChangeStatus(updateUser);
                    return Ok(new
                    {
                        message = "Edit user success!",
                        status = 200,
                        data = _userService.GetUserInformation(userId)
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetAllEmailUser")]
        public ActionResult GetEmailList()
        {
            try
            {
                var emailList = _userService.GetAllEmailUser();
                return Ok(emailList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] Login login)
        {
            try
            {
                var result = _userService.Login(login.Account, login.Password, _configuration);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
