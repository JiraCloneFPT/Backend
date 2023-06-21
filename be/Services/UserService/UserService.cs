using be.Models;
using be.Repositories.UserRepository;

namespace be.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public string GenerateAccount(string fullName)
        {
           return  _userRepository.GenerateAccount(fullName);
        }

        public string GenerateRandomString()
        {
            return _userRepository.GenerateRandomString();
        }

        public IList<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public string RemoveAccents(string input)
        {
            return _userRepository.RemoveAccents(input);
        }

        public string ReplaceVietnameseCharacters(string text)
        {
            return _userRepository.ReplaceVietnameseCharacters(text);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id); 
        }
    }
}
