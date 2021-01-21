using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using data.Interfaces;
using models.DbModels;

namespace business.Implementations
{
    public class Education : IEducation
    {
        private readonly IEducationDetailsRepository _education;
        private readonly IReviewRepository _review;
        public Education(IEducationDetailsRepository education, IReviewRepository review)
        {
            _review = review;
            _education = education;

        }
        public async Task<IEnumerable<EducationDetail>> GetDetails(int applicantId)
        {
            return await _education.GetDetails(applicantId);
        }

        public async Task<EducationDetail> SaveDetails(EducationDetail details)
        {
            await _education.SaveDetails(details);
            string applicationStatus;
            if (await _education.EducationDetailsExistsForApplicant(details.ApplicantId))
                applicationStatus = "Completed";
            else
                applicationStatus = "Submitted";
            await _review.SetApplicationStatus(details.ApplicantId, applicationStatus);
            return details; 
        }
        public async Task<EducationDetail> GetDetailById(int id)
        {
            return await _education.GetDetailById(id);
        }
        public async Task<EducationDetail> Delete(EducationDetail detail)
        {
            await _education.Delete(detail);
            string applicationStatus;
            if (await _education.EducationDetailsExistsForApplicant(detail.ApplicantId))
                applicationStatus = "Completed";
            else
                applicationStatus = "Submitted";
            await _review.SetApplicationStatus(detail.ApplicantId, applicationStatus);
            return detail;


        }

        public async Task<bool> DetailExists(int id)
        {
            return await _education.Exists(id);
        }

        public async Task<EducationDetail> EditDetails(EducationDetail detail)
        {
            return await _education.Update(detail);
        }
    }
}