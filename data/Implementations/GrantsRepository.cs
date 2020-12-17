using System.Collections.Generic;
using System.Threading.Tasks;
using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.DbModels;

namespace data.Implementations
{
    public class GrantsRepository : IGrantsRepository
    {
        private readonly DataContext _context;
        public GrantsRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<GrantProgram> DeleteGrant(GrantProgram program)
        {

            _context.GrantProgram.Remove(program);
            await _context.SaveChangesAsync();
            return program;

        }


        public async Task<GrantProgram> GetGrantbyId(int id)
        {
            return await _context.GrantProgram.FindAsync(id);
        }

        public async Task<IEnumerable<GrantProgram>> GetGrants()
        {
            return await _context.GrantProgram.ToListAsync();
        }

        public async Task<bool> ProgramExists(int id)
        {
            return await _context.GrantProgram.AnyAsync(x => x.Id == id);
        }

        public async Task<GrantProgram> SaveGrants(GrantProgram program)
        {
            _context.GrantProgram.Add(program);
            await _context.SaveChangesAsync();
            return program;
        }

        public async Task<GrantProgram> UpdateGrant(GrantProgram program)
        {
            _context.Entry(program).State = EntityState.Modified; 
            await _context.SaveChangesAsync(); 
            return program; 
        }

    }
}