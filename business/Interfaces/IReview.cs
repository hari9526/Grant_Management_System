using System.Collections.Generic;
using System.Threading.Tasks;
using models.DTOs; 

namespace business.Interfaces
{
    public interface IReview
    {
        //Getting all the reviews
        Task<IEnumerable<ReviewDto>> GetDetails(); 
        //Updating the review 
        Task<ReviewDto> UpdateReview(ReviewDto review);  
    }
}