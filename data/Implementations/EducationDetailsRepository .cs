using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.DbModels;
using models.DTOs;

namespace data.Implementations
{
    public class EducationDetailsRepository : IEducationDetailsRepository
    {
        private readonly DataContext _context;
        public EducationDetailsRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<EducationDetail>> GetDetails(int applicantId)
        {
            var result = await _context.EducationDetails.Where( x=> x.ApplicantId == applicantId).ToListAsync();     
            return result; 
        }

        public async Task<EducationDetail> SaveDetails(EducationDetail details)
        {
            await _context.EducationDetails.AddAsync(details); 
            await _context.SaveChangesAsync(); 
            return details; 
        }

        public async Task<EducationDetail> Delete(EducationDetail details)
        {
            _context.EducationDetails.Remove(details); 
            await _context.SaveChangesAsync(); 
            return details;
            
        }

        public Task<EducationDetail> Update(EducationDetail details)
        {
            return await details; 
        }
    }

        

}