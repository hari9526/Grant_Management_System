
using data.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using models.DbModels;

namespace API.Controllers
{
    public class BuggyController : BaseController
    {
        
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
            
        }

        [Authorize]
        [HttpGet("auth")]       
        public ActionResult<string> GetSecret(){
            return "secret text"; 
        }

        [HttpGet("not-found")]       
        public ActionResult<UserInfo> GetNotFound(){
            var thing = _context.UserInfo.Find(-1); 
            if(thing == null) 
                return NotFound(); 
            else    
                return Ok(thing); 
        }

        [HttpGet("server-error")]       
        public ActionResult<string> GetServerError(){
            var thing = _context.UserInfo.Find(-1);  
            var thingToReturn = thing.ToString(); 
            return thingToReturn; 
        }
        

         [HttpGet("bad-request")]       
        public ActionResult<string> GetBadRequest(){
            return BadRequest("This wasn't a good request");  
        }
    }
}