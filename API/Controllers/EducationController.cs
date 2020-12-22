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
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EducationDetail>>> GetDetails(int id)
        {
            return new ActionResult<IEnumerable<EducationDetail>>(await _education.GetDetails(id));
        }
        [HttpPost("save")]
        public async Task<ActionResult<EducationDetail>> SaveDetails(EducationDetail detail){
            return await _education.SaveDetails(detail); 
        }
    }
}