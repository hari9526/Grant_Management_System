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
            var result = await _context.EducationDetails.Where(x => x.ApplicantId == applicantId).ToListAsync();
            return result;
        }

        public async Task<EducationDetail> SaveDetails(EducationDetail details)
        {
            await _context.EducationDetails.AddAsync(details);
            await _context.SaveChangesAsync();
            return details;
        }
        public async Task<EducationDetail> GetDetailById(int id)
        {
            return await _context.EducationDetails.FindAsync(id);
        }

        public async Task<EducationDetail> Delete(EducationDetail details)
        {
            _context.EducationDetails.Remove(details);
            await _context.SaveChangesAsync();
            return details;

        }

        public async Task<EducationDetail> Update(EducationDetail details)
        {
            _context.Entry(details).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return details;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.EducationDetails.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> EducationDetailsExistsForApplicant(int applicantId)
        {
            return await _context.EducationDetails.AnyAsync(x => x.ApplicantId == applicantId);
        }
    }
}