using System.Collections.Generic;
using System.Threading.Tasks;
using models.DbModels;
using models.DTOs;

namespace data.Interfaces
{
    public interface IEducationDetailsRepository
    {
        Task<EducationDetail> SaveDetails(EducationDetail details); 
        Task<IEnumerable<EducationDetail>> GetDetails(int applicantId); 
        Task<EducationDetail> GetDetailById(int id); 
        Task<EducationDetail> Delete(EducationDetail details); 
        Task<EducationDetail> Update(EducationDetail details); 
        Task<bool> Exists (int id); 

        Task<bool> EducationDetailsExistsForApplicant(int applicantId); 

    }
}