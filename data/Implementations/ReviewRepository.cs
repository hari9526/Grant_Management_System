using System.Collections.Generic;
using System.Threading.Tasks;
using data.Data;
using data.Interfaces;
using models.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace data.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<ReviewDto>> GetDetails()
        {
             
            var result = (from  applicant in _context.ApplicantDetails
                        join  mapping in _context.UserGrantMappings on applicant.Id equals mapping.UserId 
                        join program in _context.GrantProgram on  mapping.GrantId equals  program.Id
                        join state in _context.States on applicant.StateId equals state.Id
                        join country in _context.Countries on state.Country_Id equals country.Id
                        select new ReviewDto{
                            Id = mapping.Id, 
                            ApplicantName = applicant.FirstName, 
                            ProgramCode = program.ProgramCode, 
                            Country = country.Name, 
                            ApplicationStatus = mapping.ApplicationStatus, 
                            ReviewerStatus = mapping.ReviewerStatus

                        });
            var details = await result.ToListAsync().ConfigureAwait(false); 
            return details; 
        }

        public async Task<ReviewDto> UpdateReview(ReviewDto review)
        {
            var result = await _context.UserGrantMappings.FindAsync(review.Id); 
            result.ReviewerStatus = review.ReviewerStatus; 
            await _context.SaveChangesAsync(); 
            return review; 
        }
    }
}