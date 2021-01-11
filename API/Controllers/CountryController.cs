using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using models.DbModels;

namespace API.Controllers
{
    public class CountryController : BaseController
    {
        private readonly ICountry _country;
        public CountryController(ICountry country)
        {
            _country = country;

        }
        [HttpGet]
        public async Task<IEnumerable<Country>> GetCountry()
        {
            return await _country.GetCountry(); 
        }
        [HttpGet("{countryId}")]
        public async Task<IEnumerable<State>> GetStates(int  countryId){
            return await _country.GetStates(countryId); 
        }
        //GetCountryByStateId(int stateId) for showing in applicant details 

    }
}