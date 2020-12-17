using models.DbModels;
using models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace data.Interfaces
{
    public interface IUserRepository
    {
        Task<UserInfo> GetUserbyId(int id); 
        Task<UserInfo> AddUser(UserInfo user); 
        Task<IEnumerable<UserInfo>> GetUsers();
        Task<bool> UserExists(string email); 
    }
}