using API.Data;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        //Gets the list of users
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUser()
        {

            return await _context.UserInfo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUser(int id)

        {
            return await _context.UserInfo.FindAsync(id);
        }
    }
}