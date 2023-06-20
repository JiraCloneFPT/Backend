using be.Models;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Globalization;
using System.Text;

namespace be.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbJiraCloneContext _context;

        public UserRepository()
        {
            _context = new DbJiraCloneContext();
        }
        public IList<User> GetAllUser()
        {
            return _context.Users.Where(user => user.RoleId == 1).ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }
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
        public  string RemoveAccents(string input)
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

        public  string ReplaceVietnameseCharacters(string text)
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
    }
}
