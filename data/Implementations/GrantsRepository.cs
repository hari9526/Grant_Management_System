using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<GrantProgram>> GetActiveGrants()
        {
            var result = await _context.GrantProgram.Where(x=>x.Status == true).ToListAsync(); 
            return result; 
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
            await _context.GrantProgram.AddAsync(program);
            await _context.SaveChangesAsync();
            return program;
        }

        public async Task<GrantProgram> UpdateGrant(GrantProgram program)
        {
            //Here, we say that the row is changed. I think, EF Core recognises 
            //the row based on the primary key value. Since we don't specify which property 
            //in the row changed, all properties of the row is updated. 
            //If the primary key is not present in the object, then a new row is inserted. 
            _context.Entry(program).State = EntityState.Modified; 
            await _context.SaveChangesAsync(); 
            return program; 
        }

    }
}