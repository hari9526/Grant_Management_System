using System.Threading.Tasks;
using business.Interfaces;
using data.Interfaces;
using models.DbModels;

namespace business.Implementations
{
    public class Applicant : IApplicant
    {
        private readonly IApplicantRepository _applicant;
        public Applicant(IApplicantRepository applicant)
        {
            _applicant = applicant;

        }
        public async Task<ApplicantDetail> Get(int userId)
        {
            return await _applicant.Get(userId); 
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