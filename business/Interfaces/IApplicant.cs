using System.Threading.Tasks;
using models.DbModels;
using models.DTOs;

namespace business.Interfaces
{
    public interface IApplicant
    {
        Task<ApplicantDetail> Get(int userId);
        Task<ApplicantDetail> Save(ApplicantDetail detail);
        Task<ApplicantDetail> Update(ApplicantDetail detail);

        Task<UserGrantMapping> GrantDetails(UserGrantMappingDto mappingDto); 
        Task<bool> DidApplicantAlreadyApply(UserGrantMappingDto mappingDto); 

    }
}