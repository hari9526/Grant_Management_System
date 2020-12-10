using System;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto userDetails)
        {
            if (await UserExists(userDetails.Email))
                return BadRequest("Email already exists!");

            var newUser = new UserInfo
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                //Save mail ids in small letters so that
                //it's easier to check
                UserName = userDetails.Email.ToLower(),
                Password = userDetails.Password,
                UserType = "Applicant",
                CreatedById = 1,
                UpdatedById = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            var userDto = new UserDto
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                Email = userDetails.Email,
                CreatedDate = newUser.CreatedDate,
                UpdatedDate = newUser.UpdatedDate,
                CreatedById = newUser.CreatedById,
                UpdatedById = newUser.UpdatedById,
                UserType = newUser.UserType
            };
            _context.UserInfo.Add(newUser);
            await _context.SaveChangesAsync();
            return userDto;
        }
        //Checks whether emailid exists
        private Task<bool> UserExists(string email)
        {
            return _context.UserInfo.AnyAsync(x => x.UserName == email);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDetails){
            var user = await _context.UserInfo.FirstOrDefaultAsync(x=>x.UserName == loginDetails.UserName); 
            if(user == null) 
                return Unauthorized("Username not found!"); 
            if(! user.Password.Equals(loginDetails.Password))
                return Unauthorized("Invalid Password");
            return new UserDto{
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Email = user.UserName, 
                CreatedById = user.CreatedById, 
                UpdatedById = user.UpdatedById, 
                CreatedDate = user.CreatedDate, 
                UpdatedDate = user.UpdatedDate, 
                UserType = user.UserType
            }; 
        }


    }
}