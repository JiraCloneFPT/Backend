using be.Models;

namespace be.Services.UserService
{
    public interface IUserService
    {
        public IList<User> GetAllUser();
        //public void AddUser(User user);

        public string GenerateAccount(string fullName);
        public string RemoveAccents(string input);
        public string ReplaceVietnameseCharacters(string text);
        public string GenerateRandomString();

        //Phan Cua Huy
        object AddUser(User user);
        IList<string> GetAllEmailUser();
        void ChangeStatus(User user);
        object Login(string accoount, string password, IConfiguration config);
        User UpdateUser(User user);
        User GetUserInformation(int userId);
    }
}
