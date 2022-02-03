using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsSiteServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private static List<Login> loginList = new List<Login>
        {
            new Login{Id = 1, user="admin",pass="admin"},
        };
        // GET: api/<LoginController>
        [HttpGet]
        public async Task<ActionResult<List<Login>>> Get()
        {
            return Ok(loginList);
        }
        
        [HttpPost]
        public async Task<ActionResult<Login>> Post([FromBody] Login login)
        {
            var itemu = loginList.Find(lo => lo.user == login.user);
            var itemp = loginList.Find(lo => lo.pass == login.pass);
            if ((itemu != null)&&(itemp!=null))
            {
                return Ok(login);
            }
            return BadRequest("notfound");
            
        }
    }
}
