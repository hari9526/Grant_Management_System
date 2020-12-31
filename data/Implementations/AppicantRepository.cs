using System.Threading.Tasks;
using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.DbModels;

namespace data.Implementations
{
    public class AppicantRepository : IApplicantRepository
    {
        private readonly DataContext _context;
        public AppicantRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<ApplicantDetail> Get(int userId)
        {
           return await  _context.ApplicantDetails.FindAsync(userId);

        }

        public async Task<ApplicantDetail> Save(ApplicantDetail detail)
        {
            await _context.ApplicantDetails.AddAsync(detail); 
            await _context.SaveChangesAsync(); 
            return detail; 
        }

        public async Task<ApplicantDetail> Update(ApplicantDetail detail)
        {
            _context.Entry(detail).State = EntityState.Modified; 
            await _context.SaveChangesAsync(); 
            return detail;             
        }
    }
}