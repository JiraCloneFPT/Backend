using be.Models;

namespace be.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public IList<User> GetAllUser();
        public void AddUser(User user);
        public string GenerateAccount(string fullName);
        public  string RemoveAccents(string input); 
        public string GenerateRandomString();

        public  string ReplaceVietnameseCharacters(string text);

        public User GetUserById(int id); 

    }
}
