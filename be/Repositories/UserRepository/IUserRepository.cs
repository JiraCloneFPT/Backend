using be.Models;
using Microsoft.AspNetCore.Mvc;

namespace be.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public IList<User> GetAllUser();
        //public void AddUser(User user);
        public string GenerateAccount(string fullName);
        public  string RemoveAccents(string input); 
        public string GenerateRandomString();

        public  string ReplaceVietnameseCharacters(string text);

        public User GetUserById(int id);

        //Phần của Huy
        object AddUser(User user);
        IList<string> GetAllEmailUser();
        void ChangeStatus(User user);
        object Login(string accoount, string password, IConfiguration config);
        User UpdateUser(User user);
        User GetUserInformation(int userId);

        // PhuNV17
        public void AddUserByExcel(User user);
        public IList<User> GetAllAccount(string account);


        Task<object> GetInfo(string token);
        #region HuyNG5 - code bổ sung
        public object ChangePassword(int userId, string newPasword);
        #endregion
    }
}
