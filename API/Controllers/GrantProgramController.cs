using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using business.Interfaces;
using models.DbModels;
using data.Data;
using System;

namespace API.Controllers
{
    public class GrantProgramController : BaseController
    {
        private readonly IGrants _grants;
        public GrantProgramController(IGrants grants)
        {
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
            //     var offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
            //    if (program.StartDate.HasValue && program.EndDate.HasValue)
            //    {
            //        program.StartDate = DateTime.SpecifyKind((DateTime)(program.StartDate + offset), DateTimeKind.Utc);
            //        program.EndDate = DateTime.SpecifyKind((DateTime)(program.EndDate + offset), DateTimeKind.Utc);
            //    }
            var result = await _grants.SaveGrants(program);
            //CreatedAtAction returns where, in which actionmethod, the pariticular 
            //created entry can be found as a header. Check the header tab in post and 
            //the location will give the url from which you can get the details of the 
            //newly created entry. This is a RESTApi standard. 
            return CreatedAtAction("GetGrants", new { id = result.Id }, result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GrantProgram>> GetGrants(int id)
        {
            return await _grants.GetGrantbyId(id);

        }

        // PUT: api/GrantProgram/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrantProgram(int id, GrantProgram program)
        {
            if (id != program.Id)
                return BadRequest();
            await _grants.UpdateGrant(program);
            return NoContent();
        }

        // DELETE: api/BankAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GrantProgram>> DeleteProgram(int id)
        {
            var program = await _grants.GetGrantbyId(id);
            // if (program == null)
            // {
            //     return NotFound();
            // }
            return await _grants.DeleteGrant(program);
        }
    }

}