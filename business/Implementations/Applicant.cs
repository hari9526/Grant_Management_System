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

        public async Task<ApplicantDto> Get(int userId)
        {
            var result = await _applicant.Get(userId);
            int? countryId;
            if (result.StateId != null)
                countryId = await _applicant.GetCountryId(result.StateId);
            else
                countryId = null;
            var applicantDetail = new ApplicantDto
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Email = result.Email,
                DateOfBirth = result.DateOfBirth,
                Country = countryId,
                State = result.StateId,
                Disabled = result.Disabled,
                Address = result.Address,
                City = result.City,
                PostalCode = result.PostalCode,
                Mobile = result.Mobile,
                Phone = result.Phone
            };
            return applicantDetail;



        }

        public async Task<int> GetCountryId(int? stateId)
        {
            return await _applicant.GetCountryId(stateId);
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

        public async Task<ApplicantDetail> Save(ApplicantDto detail)
        {
            var applicantDetail = new ApplicantDetail{
                Id = detail.Id, 
                FirstName = detail.FirstName, 
                LastName = detail.LastName, 
                Email = detail.Email, 
                DateOfBirth = detail.DateOfBirth, 
                StateId = detail.State, 
                Disabled = detail.Disabled, 
                Address = detail.Address, 
                City = detail.City, 
                PostalCode = detail.PostalCode, 
                Mobile = detail.Mobile, 
                Phone = detail.Phone
              
            }; 
            return await _applicant.Save(applicantDetail);
        }

        public async Task<ApplicantDetail> Update(ApplicantDto detail)
        {
            var details = new ApplicantDetail{
                Id = detail.Id, 
                FirstName = detail.FirstName, 
                LastName = detail.LastName, 
                Email = detail.Email, 
                DateOfBirth = detail.DateOfBirth, 
                StateId = detail.State, 
                Disabled = detail.Disabled, 
                Address = detail.Address, 
                City = detail.City, 
                PostalCode = detail.PostalCode, 
                Mobile = detail.Mobile, 
                Phone = detail.Phone
            }; 
            return await _applicant.Update(details);
        }
    }
}