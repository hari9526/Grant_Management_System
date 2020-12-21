
using business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;            
        }
        // [Authorize]
        // //Gets the list of users
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUser()
        {

            return new ActionResult<IEnumerable<UserInfo>>(await _user.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUser(int id)

        {
            return await _user.GetUserbyId(id);
        }
    }
}