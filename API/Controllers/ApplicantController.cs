using System.Threading.Tasks;
using business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using models.DbModels;

namespace API.Controllers
{
    public class ApplicantController : BaseController
    {
        private readonly IApplicant _applicant;
        public ApplicantController(IApplicant applicant)
        {
            _applicant = applicant;

        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<ApplicantDetail>> GetDetails(int userId)
        {
            return await _applicant.Get(userId);
           
        }


        [HttpPost]
        public async Task<ActionResult<ApplicantDetail>> SaveDetails(ApplicantDetail detail)
        {
            var result = await _applicant.Save(detail);
            return CreatedAtAction("GetDetails", new { userId = result.Id }, result);
        }
        [HttpPut("{applicantId}")]
        public async Task<ActionResult<ApplicantDetail>> UpdateDetails(int applicantId, ApplicantDetail detail)
        {
            if(applicantId != detail.Id)
                return BadRequest(); 
            return await _applicant.Update(detail); 
        }



    }
}