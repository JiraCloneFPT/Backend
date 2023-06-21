﻿using be.Models;
using be.Repositories.UserRepository;

namespace be.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        //public void AddUser(User user)
        //{
        //    _userRepository.AddUser(user);
        //}

        public object AddUser(User user)
        {
            _userRepository.AddUser(user);
            return user;
        }


        public void ChangeStatus(User user)
        {
            _userRepository.ChangeStatus(user);
        }

        public string GenerateAccount(string fullName)
        {
           return  _userRepository.GenerateAccount(fullName);
        }

        public string GenerateRandomString()
        {
            return _userRepository.GenerateRandomString();
        }

        public IList<string> GetAllEmailUser()
        {
            return _userRepository.GetAllEmailUser();
        }

        public IList<User> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public User GetUserInformation(int userId)
        {
            return _userRepository.GetUserInformation(userId);
        }

        public object Login(string accoount, string password, IConfiguration config)
        {
            return _userRepository.Login(accoount, password, config);
        }

        public string RemoveAccents(string input)
        {
            return _userRepository.RemoveAccents(input);
        }

        public string ReplaceVietnameseCharacters(string text)
        {
            return _userRepository.ReplaceVietnameseCharacters(text);
        }

        public User UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            User updateUser = _userRepository.GetUserInformation(user.UserId);
            return updateUser;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id); 
        }
    }
}