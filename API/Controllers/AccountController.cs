using System;
using System.Threading.Tasks;
using API.Data;

using API.Model;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using business.Interfaces;
using models.DTOs;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContext _context;
        private readonly ITokenServices _tokenService;
        private readonly IUser _user;
        public AccountController(DataContext context, ITokenServices tokenService, IUser user)
        {
            _user = user;
            _tokenService = tokenService;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto userDetails)
        {
            if (await _user.UserExists(userDetails.Email))
                return BadRequest("Email already exists!");
            //Adding user to the database
            var newUser =  await _user.AddUser(userDetails); 
            var userDto = new UserDto
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                Email = userDetails.Email,
                CreatedDate = newUser.CreatedDate,
                UpdatedDate = newUser.UpdatedDate,
                CreatedById = newUser.CreatedById,
                UpdatedById = newUser.UpdatedById,
                UserType = newUser.UserType,
                Token = _tokenService.CreateToken(newUser)
            };       
            return userDto;
        }
   
        // [HttpPost("login")]
        // public async Task<ActionResult<UserDto>> Login(LoginDto loginDetails)
        // {
        //     var user = await _context.UserInfo.FirstOrDefaultAsync(x => x.UserName == loginDetails.UserName);
        //     if (user == null)
        //         return Unauthorized("Username not found!");
        //     if (!user.Password.Equals(loginDetails.Password))
        //         return Unauthorized("Invalid Password");
        //     return new UserDto
        //     {
        //         FirstName = user.FirstName,
        //         LastName = user.LastName,
        //         Email = user.UserName,
        //         CreatedById = user.CreatedById,
        //         UpdatedById = user.UpdatedById,
        //         CreatedDate = user.CreatedDate,
        //         UpdatedDate = user.UpdatedDate,
        //         UserType = user.UserType,
        //         Token = _tokenService.CreateToken(user)
        //     };
        // }


    }
}