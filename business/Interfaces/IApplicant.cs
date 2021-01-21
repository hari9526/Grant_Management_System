using System.Threading.Tasks;
using models.DbModels;
using models.DTOs;

namespace business.Interfaces
{
    public interface IApplicant
    {
        Task<ApplicantDto> Get(int userId);
        Task<ApplicantDetail> Save(ApplicantDto detail);
        Task<ApplicantDetail> Update(ApplicantDto detail);

        Task<UserGrantMapping> GrantDetails(UserGrantMappingDto mappingDto); 
        Task<bool> DidApplicantAlreadyApply(UserGrantMappingDto mappingDto);
        Task<int> GetCountryId(int? stateId);
    }
}