using System.Collections.Generic;
using System.Threading.Tasks;
using models.DbModels;
using models.DTOs;

namespace business.Interfaces
{
    public interface IUser
    {
        Task<UserInfo> AddUser(RegisterDto register); 
        Task<UserInfo> GetUserbyId(int id); 
        Task<IEnumerable<UserInfo>> GetUsers(); 
        Task<bool> UserExists(string email);   

    }
}