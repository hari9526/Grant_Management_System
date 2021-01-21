using System.Collections.Generic;
using System.Threading.Tasks;
using models.DbModels;

namespace business.Interfaces
{
    public interface IEducation
    {
        Task<EducationDetail> SaveDetails(EducationDetail details);
        Task<IEnumerable<EducationDetail>> GetDetails(int applicantId);
        Task<EducationDetail> GetDetailById (int id);
        Task<EducationDetail> EditDetails(EducationDetail detail);
        Task<bool> DetailExists(int id);
        Task<EducationDetail> Delete(EducationDetail detail);


    }
}