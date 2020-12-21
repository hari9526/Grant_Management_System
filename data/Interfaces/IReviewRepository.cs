using System.Collections.Generic;
using System.Threading.Tasks;
using models.DTOs;

namespace data.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<ReviewDto>> GetDetails(); 
        Task<ReviewDto> UpdateReview(ReviewDto review); 
        
    }
}