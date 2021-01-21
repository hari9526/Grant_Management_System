using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using data.Interfaces;
using models.DbModels;

namespace business.Implementations
{
    public class Country : ICountry
    {
        private readonly ICountryRepository _country;
        public Country(ICountryRepository country)
        {
            _country = country;

        }
        public async Task<IEnumerable<models.DbModels.Country>> GetCountry()
        {
            return await _country.GetCountry(); 
        }

        public async Task<IEnumerable<State>> GetStates(int countryId)
        {
            return await _country.GetStates(countryId); 
        }
    }
}