using System.Threading.Tasks;
using models.DbModels;
using models.DTOs;

namespace data.Interfaces
{
    public interface IApplicantRepository
    {
        Task<ApplicantDetail> Get(int userId);
        Task<ApplicantDetail> Save(ApplicantDetail detail);
        Task<ApplicantDetail> Update(ApplicantDetail detail);
        Task<UserGrantMapping> SaveGrantDetails(UserGrantMapping mappingDetails);

        Task<bool> DidApplicantAlreadyApply(UserGrantMappingDto mappingDto);
        Task<int> GetCountryId(int? stateId);
    }
}