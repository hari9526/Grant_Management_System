using System.Collections.Generic;
using System.Threading.Tasks;
using models.DbModels;

namespace data.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountry(); 
        Task<IEnumerable<State>> GetStates(int  countryId); 
        
    }
}