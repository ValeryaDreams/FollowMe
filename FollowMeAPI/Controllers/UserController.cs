using FollowMeAPI.Data;
using FollowMeAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMeAPI.Controllers
{
        [Route("[controller]")]
        [ApiController]
        [EnableCors("MyPolicy")]
        public class UserController : ControllerBase
        {
                private readonly FollowMeContext _context;

                public  UserController(FollowMeContext context)
                {
                        _context = context;       
                }

                [HttpGet]
                [Route("GetAll")]
                public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
                {
                        return Ok(await _context.User.ToListAsync());
                }

        }
}
