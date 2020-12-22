using System.Collections.Generic;
using System.Threading.Tasks;
using models.DbModels;

namespace business.Interfaces
{
    public interface IEducation
    {
        Task<EducationDetail> SaveDetails(EducationDetail details);
        Task<IEnumerable<EducationDetail>> GetDetails(int applicantId);
    }
}