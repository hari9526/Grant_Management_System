using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.DbModels;

namespace data.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Country>> GetCountry()
        {
            return await _context.Countries.ToListAsync(); 
        }

        public async Task<IEnumerable<State>> GetStates(int countryId)
        {
            return await _context.States.Where(x=>x.Country_Id == countryId).ToListAsync(); 
        }
    }
}