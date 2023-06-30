using be.Models;
using Microsoft.AspNetCore.Mvc;

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

        public User GetUserById(int id);

        //Phan Cua Huy
        object AddUser(User user);
        IList<string> GetAllEmailUser();
        void ChangeStatus(User user);
        object Login(string accoount, string password, IConfiguration config);
        User UpdateUser(User user);
        User GetUserInformation(int userId);
        Task<object> GetInfo(string token);

        #region PhuNV17
        public void AddUserByExcel(User user);
        public IList<User> GetAllAccount(string account);
        public List<string> GetListEmailUsers(List<int> listId);
        public string GenerateAccountFromName(string fullName);

        #endregion

        #region HuyNG5 - code bổ sung
        public object ChangePassword (int userId, string password);
        #endregion
    }
}
