using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using models.DTOs;

namespace API.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReview _review;
        public ReviewController(IReview review)
        {
            _review = review;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews()
        {
            return new ActionResult<IEnumerable<ReviewDto>>(await _review.GetDetails()); 

        }
        [HttpPost]
        public async Task<ActionResult<ReviewDto>> UpdateReview(ReviewDto review)
        {
            var result =  await _review.UpdateReview(review); 
            return result; 
        }

        //View all Applicants 

        //Update Applicant

    }
}