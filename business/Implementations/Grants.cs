using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using data.Interfaces;
using models.DbModels;

namespace business.Implementations
{
    public class Grants : IGrants
    {
        private readonly IGrantsRepository _grantRepository;
        public Grants(IGrantsRepository grantRepository)
        {
            _grantRepository = grantRepository;

        }
        public async Task<GrantProgram> DeleteGrant(GrantProgram program)
        {
            return await _grantRepository.DeleteGrant(program); 
        }

  

        public async Task<GrantProgram> GetGrantbyId(int id)
        {
            return await _grantRepository.GetGrantbyId(id); 
        }

        public async Task<IEnumerable<GrantProgram>> GetGrants()
        {
            return await _grantRepository.GetGrants(); 
        }


        public async Task<GrantProgram> SaveGrants(GrantProgram program)
        {
            return await _grantRepository.SaveGrants(program); 
        }

        public async Task<GrantProgram> UpdateGrant(GrantProgram program)
        {
             return await _grantRepository.UpdateGrant(program); 
        }

        public async Task<bool> ProgramExists(int id)
        {
            return await _grantRepository.ProgramExists(id); 
        }
    }
}