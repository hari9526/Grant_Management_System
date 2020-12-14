using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Model;
using System.Linq;

namespace API.Controllers
{
    public class GrantProgramController : BaseController
    {
        private readonly DataContext _context;
        public GrantProgramController(DataContext context)
        {
            _context = context;

        }

        public async Task<ActionResult<IEnumerable<GrantProgram>>> GetGrants()
        {
            return await _context.GrantProgram.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<GrantProgram>> SaveGrants(GrantProgram program)
        {
            _context.GrantProgram.Add(program);
            await _context.SaveChangesAsync();
            //CreatedAtAction returns where, in which actionmethod, the pariticular 
            //created entry can be found as a header. Check the header tab in post and 
            //the location will give the url from which you can get the details of the 
            //newly created entry. This is a RESTApi standard. 
            return CreatedAtAction("GetGrants", new { id = program.Id }, program);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GrantProgram>> GetGrants(int id)
        {
            var grant = await _context.GrantProgram.FindAsync(id);

            if (grant == null)
            {
                return NotFound();
            }

            return grant;
        }

        // PUT: api/GrantProgram/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrantProgram(int id, GrantProgram program)
        {
            if (id != program.Id)
            {
                return BadRequest();
            }

            _context.Entry(program).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool ProgramExists(int id)
        {
            return _context.GrantProgram.Any(e => e.Id == id);
        }
         // DELETE: api/BankAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GrantProgram>> DeleteProgram(int id)
        {
            var program = await _context.GrantProgram.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            _context.GrantProgram.Remove(program);
            await _context.SaveChangesAsync();

            return program;
        }
    }

}