using System.Collections.Generic;
using System.Threading.Tasks;
using business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using models.DbModels;

namespace API.Controllers
{
    public class EducationController : BaseController
    {
        private readonly IEducation _education;
        public EducationController(IEducation education)
        {
            _education = education;

        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<EducationDetail>>> GetDetails(int userId)
        {
            return new ActionResult<IEnumerable<EducationDetail>>(await _education.GetDetails(userId));
        }
        [HttpPost("save")]
        public async Task<ActionResult<EducationDetail>> SaveDetails(EducationDetail detail)
        {
            return await _education.SaveDetails(detail);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EducationDetail>> Edit(int id, EducationDetail detail)
        {
            if (id != detail.Id)
                return BadRequest();
            // if (!(await _education.DetailExists(detail.Id)))
            //     return NotFound();
            await _education.EditDetails(detail);
            return detail;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<EducationDetail>> Delete(int id)
        {
            var detail = await _education.GetDetailById(id);
            // if(detail == null)
            //     return NotFound(); 
            return await _education.Delete(detail);              
        }

    }
}