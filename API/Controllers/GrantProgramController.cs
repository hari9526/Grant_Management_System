using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using business.Interfaces;
using models.DbModels;
using data.Data;

namespace API.Controllers
{
    public class GrantProgramController : BaseController
    {

        private readonly DataContext _context;

        private readonly IGrants _grants;
        public GrantProgramController(IGrants grants, DataContext context)
        {
            _context = context;
            _grants = grants;


        }

        public async Task<ActionResult<IEnumerable<GrantProgram>>> GetGrants()
        {
            //return await _context.GrantProgram.ToListAsync();
            return new ActionResult<IEnumerable<GrantProgram>>(await _grants.GetGrants());
        }

        [HttpPost]
        public async Task<ActionResult<GrantProgram>> SaveGrants(GrantProgram program)
        {
            await _grants.SaveGrants(program);
            //CreatedAtAction returns where, in which actionmethod, the pariticular 
            //created entry can be found as a header. Check the header tab in post and 
            //the location will give the url from which you can get the details of the 
            //newly created entry. This is a RESTApi standard. 
            return CreatedAtAction("GetGrants", new { id = program.Id }, program);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GrantProgram>> GetGrants(int id)
        {
            var grant = await _grants.GetGrantbyId(id);

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

            try
            {
                await _grants.UpdateGrant(program);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _grants.ProgramExists(id))
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

        // DELETE: api/BankAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GrantProgram>> DeleteProgram(int id)
        {
            var program = await _grants.GetGrantbyId(id);
            if (program == null)
            {
                return NotFound();
            }
            return await _grants.DeleteGrant(program);
        }
    }

}