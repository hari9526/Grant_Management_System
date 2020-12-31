using System.Threading.Tasks;
using business.Interfaces;
using data.Interfaces;
using models.DbModels;
using models.DTOs;

namespace business.Implementations
{
    public class Applicant : IApplicant
    {
        private readonly IApplicantRepository _applicant;
        private readonly IEducationDetailsRepository _education;
        public Applicant(IApplicantRepository applicant, IEducationDetailsRepository education)
        {
            _education = education;
            _applicant = applicant;

        }

        public async Task<bool> DidApplicantAlreadyApply(UserGrantMappingDto mappingDto)
        {
            return await _applicant.DidApplicantAlreadyApply(mappingDto); 
        }

        public async Task<ApplicantDetail> Get(int userId)
        {
            return await _applicant.Get(userId);
        }

        public async Task<UserGrantMapping> GrantDetails(UserGrantMappingDto mappingDto)
        {
            string applicationStatus;
            if (await _education.EducationDetailsExistsForApplicant(mappingDto.UserId))
                applicationStatus = "Completed"; 
            else    
                applicationStatus = "Submitted"; 

            var mappingDetails = new UserGrantMapping
            {
                UserId = mappingDto.UserId,
                GrantId = mappingDto.GrantId, 
                ApplicationStatus = applicationStatus
            };
            return await _applicant.SaveGrantDetails(mappingDetails); 
        }

        public async Task<ApplicantDetail> Save(ApplicantDetail detail)
        {
            return await _applicant.Save(detail);
        }

        public async Task<ApplicantDetail> Update(ApplicantDetail detail)
        {
            return await _applicant.Update(detail);
        }
    }
}