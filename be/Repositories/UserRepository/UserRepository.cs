using be.Models;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using be.Services.OtherService;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace be.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbJiraCloneContext _context;

        public UserRepository()
        {
            _context = new DbJiraCloneContext();
        }
        

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.UserId == id);
        }

        public object AddUser(User user)
        {
            var account = GenerateAccount(user.FullName);
            user.AccountName = ReplaceVietnameseCharacters(account);
            user.Status = "1";
            user.RoleId = 2;
            user.Password = GenerateRandomString();
            _context.Users.Add(user);
            _context.SaveChanges();
            try
            {
                EmailService.Instance.SendMail(user.Email, 2, user.FullName, user.AccountName, user.Password);
            }
            catch
            {
                return new
                {
                    message = "Send mail failed!",
                    status = 400
                };
            }
            return user;
        }

        // PhuNV17 function
        public void AddUserByExcel(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public IList<User> GetAllUser()
        {
            return _context.Users.ToList();
            //return _context.Users.W;
        }

        //public void AddUser(User user)
        //{
        //    _context.Users.Add(user);

        //    _context.SaveChanges();
        //}
        //public async Task<Object> AddUserSample(User user)
        //{
        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //    return new
        //    {
        //        message = "hello",
        //        status = 200,
        //        data = user
        //    };
        //}

        public void AddUserByExcel()
        {

        }

        public IList<Record> ReadExcelFile(string filePath)
        {
            IList<Record> records = new List<Record>();
            return records; 
        }
        public string RemoveAccents(string input)
        {
            string decomposed = input.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            foreach (char c in decomposed)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }

            return builder.ToString();
        }

        public string ReplaceVietnameseCharacters(string text)
        {
            Dictionary<char, char> replacements = new Dictionary<char, char>()
    {
        {'á', 'a'}, {'à', 'a'}, {'ả', 'a'}, {'ã', 'a'}, {'ạ', 'a'}, {'ă', 'a'}, {'ắ', 'a'}, {'ằ', 'a'}, {'ẳ', 'a'}, {'ẵ', 'a'}, {'ặ', 'a'},
        {'â', 'a'}, {'ấ', 'a'}, {'ầ', 'a'}, {'ẩ', 'a'}, {'ẫ', 'a'}, {'ậ', 'a'},
        {'đ', 'd'},
        {'é', 'e'}, {'è', 'e'}, {'ẻ', 'e'}, {'ẽ', 'e'}, {'ẹ', 'e'}, {'ê', 'e'}, {'ế', 'e'}, {'ề', 'e'}, {'ể', 'e'}, {'ễ', 'e'}, {'ệ', 'e'},
        {'í', 'i'}, {'ì', 'i'}, {'ỉ', 'i'}, {'ĩ', 'i'}, {'ị', 'i'},
        {'ó', 'o'}, {'ò', 'o'}, {'ỏ', 'o'}, {'õ', 'o'}, {'ọ', 'o'}, {'ô', 'o'}, {'ố', 'o'}, {'ồ', 'o'}, {'ổ', 'o'}, {'ỗ', 'o'}, {'ộ', 'o'},
        {'ơ', 'o'}, {'ớ', 'o'}, {'ờ', 'o'}, {'ở', 'o'}, {'ỡ', 'o'}, {'ợ', 'o'},
        {'ú', 'u'}, {'ù', 'u'}, {'ủ', 'u'}, {'ũ', 'u'}, {'ụ', 'u'}, {'ư', 'u'}, {'ứ', 'u'}, {'ừ', 'u'}, {'ử', 'u'}, {'ữ', 'u'}, {'ự', 'u'},
        {'ý', 'y'}, {'ỳ', 'y'}, {'ỷ', 'y'}, {'ỹ', 'y'}, {'ỵ', 'y'},
        {'Á', 'A'}, {'À', 'A'}, {'Ả', 'A'}, {'Ã', 'A'}, {'Ạ', 'A'}, {'Ă', 'A'}, {'Ắ', 'A'}, {'Ằ', 'A'}, {'Ẳ', 'A'}, {'Ẵ', 'A'}, {'Ặ', 'A'},
        {'Â', 'A'}, {'Ấ', 'A'}, {'Ầ', 'A'}, {'Ẩ', 'A'}, {'Ẫ', 'A'}, {'Ậ', 'A'},
        {'Đ', 'D'},
        {'É', 'E'}, {'È', 'E'}, {'Ẻ', 'E'}, {'Ẽ', 'E'}, {'Ẹ', 'E'}, {'Ê', 'E'}, {'Ế', 'E'}, {'Ề', 'E'}, {'Ể', 'E'}, {'Ễ', 'E'}, {'Ệ', 'E'},
        {'Í', 'I'}, {'Ì', 'I'}, {'Ỉ', 'I'}, {'Ĩ', 'I'}, {'Ị', 'I'},
        {'Ó', 'O'}, {'Ò', 'O'}, {'Ỏ', 'O'}, {'Õ', 'O'}, {'Ọ', 'O'}, {'Ô', 'O'}, {'Ố', 'O'}, {'Ồ', 'O'}, {'Ổ', 'O'}, {'Ỗ', 'O'}, {'Ộ', 'O'},
        {'Ơ', 'O'}, {'Ớ', 'O'}, {'Ờ', 'O'}, {'Ở', 'O'}, {'Ỡ', 'O'}, {'Ợ', 'O'},
        {'Ú', 'U'}, {'Ù', 'U'}, {'Ủ', 'U'}, {'Ũ', 'U'}, {'Ụ', 'U'}, {'Ư', 'U'}, {'Ứ', 'U'}, {'Ừ', 'U'}, {'Ử', 'U'}, {'Ữ', 'U'}, {'Ự', 'U'},
        {'Ý', 'Y'}, {'Ỳ', 'Y'}, {'Ỷ', 'Y'}, {'Ỹ', 'Y'}, {'Ỵ', 'Y'}
    };

            foreach (KeyValuePair<char, char> replacement in replacements)
            {
                text = text.Replace(replacement.Key, replacement.Value);
            }
            return text;
        }

        public string GenerateAccount(string fullName)
        {
            string[] names = fullName.Split(" ");
            string lastName = names[names.Length - 1];
            string plusCharacter = null;
            if (names.Length == 2)
            {
                string firstChar = names[0].Substring(0, 1);
                plusCharacter = firstChar;
            }
            else
            {
                for (int i = 0; i < names.Length - 1; i++)
                {
                    string firstChar = names[i].Substring(0, 1);
                    plusCharacter += firstChar;
                }
            }
            var listUser = _context.Users.ToList();
            var count = listUser.Where(x => x.FullName == fullName).ToList().Count();
            var account = "";
            if (count >= 1)
            {
                account = lastName + plusCharacter.ToUpper() + (count + 1);
            }
            else
            {
                account = lastName + plusCharacter.ToUpper();
            }
            return account;
        }
        public string GenerateRandomString()
        {
            Random random = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomChars = new char[10];
            randomChars[0] = characters[random.Next(26)];
            for (int i = 1; i < 10; i++)
            {
                randomChars[i] = characters[random.Next(characters.Length)];
            }
            string randomString = new string(randomChars);
            return randomString;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IList<string> GetAllEmailUser()
        {
            var emailList = (from user in _context.Users
                             select user.Email).ToList();
            return emailList;
        }

        public void ChangeStatus(User user)
        {
            var updateStatusUser = _context.Users.SingleOrDefault(x => x.UserId == user.UserId);
            updateStatusUser.Status = user.Status;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public string CreateToken(string email, int id, IConfiguration config)
        {
            string role = _context.RoleUsers.Find(id).RoleName;
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                config.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return "bearer "+ jwt;
        }
        public object Login(string accoount, string password, IConfiguration config)
        {
            string token = "";
            //var user = _context.Users.SingleOrDefault(x => x.AccountName.ToLower() == accoount.ToLower());
            var user = _context.Users.Where(e=>e.AccountName.Equals(accoount)).FirstOrDefault();
            if (user == null)
            {
                return new
                {
                    status = 404,
                    message = "The account is not found"
                };
            }
            if (user.Password != password)
            {
                return new
                {
                    status = 404,
                    message = "Password is wrong"
                };
            }
            if (user.Status == "0")
            {
                return new
                {
                    status = 404,
                    message = "Your account is blocked. Please contact to admin"
                };
            }
            token = CreateToken(user.Email, (int)user.RoleId, config);
            if (user.AccountName == accoount && user.Password == password && user.Status == "1")
            {
                return new
                {
                    message = "Login success!",
                    status = 200,
                    data = user,
                    token
                };
            }
            return null;
        }

        public User UpdateUser(User user)
        {
            var updateUser = _context.Users.SingleOrDefault(x => x.UserId == user.UserId);
            var account = GenerateAccount(user.FullName);
            updateUser.AccountName = ReplaceVietnameseCharacters(account);
            updateUser.FullName = user.FullName;
            updateUser.Email = user.Email;
            updateUser.Birthday = user.Birthday;
            _context.SaveChanges();
            EmailService.Instance.SendMail(user.Email, 3, updateUser.FullName, updateUser.AccountName, user.Password);
            return updateUser;
        }

        public User GetUserInformation(int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            return user;
        }

        #region HUYNG5 - code bổ sung 
        public object ChangePassword(int userId, string newPasword)
        {
            var getUser = _context.Users.SingleOrDefault(x => x.UserId == userId);
            if(getUser == null)
            {
                return new
                {
                    status = 404,
                    message = "Not found account"
                };
            } else
            {
                getUser.Password = newPasword;
                _context.SaveChanges();
                return new
                {
                    message = "Change password successfully",
                    status = 200,
                    data = getUser
                };
            }
        }
        #endregion



        public async Task<object> GetInfo(string token)
        {
            string _token = token.Split(' ')[1];
            if (_token == null)
            {
                return new
                {
                    message = "Token is wrong!",
                    status = 400
                };
            }
            var handle = new JwtSecurityTokenHandler();
            string email = handle.ReadJwtToken(_token).Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user == null)
            {
                return new
                {
                    message = "User is not found!",
                    status = 404
                };
            }
            return new
            {
                message = "Get information success!",
                status = 200,
                data = user,
            };
        }

        #region PhuNV17
        public IList<User> GetAllAccount(string account)
        {
            IList<User> accounts = new List<User>();
            accounts = _context.Users.Where(user => user.AccountName == account).ToList();
            return accounts;

        }

        public List<string> GetListEmailUsers(List<int> listId)
        {
           List<string> emailList = new List<string>();

            for (int i = 0; i < listId.Count; i++)
            {
                string email = _context.Users.FirstOrDefault(x => x.UserId == listId[i]).Email;
                emailList.Add(email);
            }
            return emailList;
        }
        #endregion
    }
}
