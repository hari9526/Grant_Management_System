using System.Collections.Generic;
using System.Threading.Tasks;
using models.DbModels;

namespace data.Interfaces
{
    public interface IGrantsRepository
    {
        Task<IEnumerable<GrantProgram>> GetGrants(); 
        Task<IEnumerable<GrantProgram>> GetActiveGrants(); 
        Task<GrantProgram> SaveGrants(GrantProgram program); 
        Task<GrantProgram> GetGrantbyId(int id); 
        Task<GrantProgram> UpdateGrant(GrantProgram program); 
        Task<bool> ProgramExists(int id); 
        Task<GrantProgram> DeleteGrant(GrantProgram program);

    }
}