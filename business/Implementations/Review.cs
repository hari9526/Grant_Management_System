using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using data.Interfaces;
using models.DTOs;

namespace business.Implementations
{
    public class Review : IReview
    {
        private readonly IReviewRepository _review;
        public Review(IReviewRepository review)
        {
            _review = review;

        }
        public async Task<IEnumerable<ReviewDto>> GetDetails()
        {
            return await _review.GetDetails(); 
            
        }

        public async Task<ReviewDto> UpdateReview(ReviewDto review)
        {
            return await _review.UpdateReview(review); 
        }
    }
}