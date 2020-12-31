using System.Threading.Tasks;
using models.DbModels;

namespace business.Interfaces
{
    public interface IApplicant
    {
        Task<ApplicantDetail> Get(int userId);
        Task<ApplicantDetail> Save(ApplicantDetail detail);
        Task<ApplicantDetail> Update(ApplicantDetail detail);

    }
}