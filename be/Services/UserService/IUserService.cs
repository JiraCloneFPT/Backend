using be.Models;

namespace be.Services.UserService
{
    public interface IUserService
    {
        public IList<User> GetAllUser();
        public void AddUser(User user);

        public string GenerateAccount(string fullName);
        public string RemoveAccents(string input);

        public string ReplaceVietnameseCharacters(string text);


        public string GenerateRandomString();

    }
}
