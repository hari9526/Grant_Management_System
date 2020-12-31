using System.Threading.Tasks;
using models.DbModels;

namespace data.Interfaces
{
    public interface IApplicantRepository
    {
        Task<ApplicantDetail> Get(int userId); 
        Task<ApplicantDetail> Save(ApplicantDetail detail); 
        Task<ApplicantDetail> Update(ApplicantDetail detail); 

        
    }
}