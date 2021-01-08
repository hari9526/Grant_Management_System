using System.Collections.Generic;
using System.Threading.Tasks;
using models.DbModels;

namespace business.Interfaces
{
    public interface ICountry
    {
        Task<IEnumerable<Country>> GetCountry(); 
        Task<IEnumerable<State>> GetStates(int  countryId); 
    }
}