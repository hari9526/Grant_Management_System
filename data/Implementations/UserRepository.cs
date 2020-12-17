using System.Collections.Generic;
using System.Threading.Tasks;
using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.DbModels;
using models.DTOs;

namespace data.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> AddUser(UserInfo user)
        {
            _context.UserInfo.Add(user);
            await _context.SaveChangesAsync();
            return user; 
        }

        public async Task<UserInfo> GetUserbyId(int id)
        {
            return await _context.UserInfo.FindAsync(id);
        }

        public async Task<IEnumerable<UserInfo>> GetUsers()
        {
            return await _context.UserInfo.ToListAsync();
        }

         //Checks whether emailid exists
        public Task<bool> UserExists(string email)
        {
            return _context.UserInfo.AnyAsync(x => x.UserName == email);
        }
    }
}