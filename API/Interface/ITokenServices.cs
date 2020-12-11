

using API.Model;

namespace API.Interface
{
    public interface ITokenServices
    {
        string CreateToken (UserInfo user); 
    }
}