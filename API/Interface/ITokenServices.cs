


using models.DbModels;

namespace API.Interface
{
    public interface ITokenServices
    {
        string CreateToken (UserInfo user); 
    }
}