using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using data.Interfaces;
using models.DbModels;
using models.DTOs;

namespace business.Implementations
{
    public class User : IUser
    {
        private readonly IUserRepository _userRepository;
        public User(IUserRepository userRepository)
        {
            _userRepository = userRepository;                   
        }
        public Task<UserInfo> AddUser(RegisterDto register)
        {

             //UserType, CreatedById, CreatedDate, UpdatedById, UpdatedDate
            var userDetailed = new UserInfo{
                FirstName = register.FirstName, 
                LastName = register.LastName, 
                UserName = register.Email, 
                Password = register.Password, 
                UserType = "Applicant",
                CreatedById = 1,
                UpdatedById = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }; 
            return _userRepository.AddUser(userDetailed); 

        }

        public Task<UserInfo> GetUserbyId(int id)
        {
            return _userRepository.GetUserbyId(id); 
        }

        public Task<IEnumerable<UserInfo>> GetUsers()
        {
            return _userRepository.GetUsers(); 
        }

        public Task<bool> UserExists(string email)
        {
            return _userRepository.UserExists(email); 
        }
    }
}