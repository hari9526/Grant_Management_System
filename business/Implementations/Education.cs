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
        public Education(IEducationDetailsRepository education)
        {
            _education = education;

        }
        public async Task<IEnumerable<EducationDetail>> GetDetails(int applicantId)
        {
            return await _education.GetDetails(applicantId); 
        }

        public async Task<EducationDetail> SaveDetails(EducationDetail details)
        {
            return await _education.SaveDetails(details); 
        }
    }
}