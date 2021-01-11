using System.Threading.Tasks;
using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.DbModels;
using models.DTOs;

namespace data.Implementations
{
    public class AppicantRepository : IApplicantRepository
    {
        private readonly DataContext _context;
        public AppicantRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<bool> DidApplicantAlreadyApply(UserGrantMappingDto mappingDto)
        {
            return await _context.UserGrantMappings.AnyAsync(x=>x.UserId == mappingDto.UserId && x.GrantId == mappingDto.GrantId); 
        }

        public async Task<ApplicantDetail> Get(int userId)
        {
           return await  _context.ApplicantDetails.FindAsync(userId);

        }

        public async Task<int> GetCountryId(int? stateId)
        {
            //converting int? to int
            int id = stateId ?? default(int); 
            var result = await _context.States.FirstOrDefaultAsync(x=>x.Id == id); 
            return result.Country_Id; 
        }

        public async Task<ApplicantDetail> Save(ApplicantDetail detail)
        {       
            await _context.ApplicantDetails.AddAsync(detail); 
            await _context.SaveChangesAsync(); 
            return detail; 
        }

        public async Task<UserGrantMapping> SaveGrantDetails(UserGrantMapping mappingDetails)
        {
            await _context.UserGrantMappings.AddAsync(mappingDetails); 
            await _context.SaveChangesAsync(); 
            return mappingDetails;

        }

        public async Task<ApplicantDetail> Update(ApplicantDetail detail)
        {
            _context.Entry(detail).State = EntityState.Modified; 
            await _context.SaveChangesAsync(); 
            return detail;             
        }
    }
}