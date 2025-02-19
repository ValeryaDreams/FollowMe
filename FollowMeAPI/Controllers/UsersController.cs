using FollowMeAPI.Data;
using FollowMeAPI.Models.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMeAPI.Controllers
{
        [Route("[controller]")]
        [ApiController]
        [EnableCors("MyPolicy")]
        public class UsersController : ControllerBase
        {
                private readonly FollowMeContext _context;

                public  UsersController(FollowMeContext context)
                {
                        _context = context;       
                }

                [HttpGet]
                [Route("GetAllUsers")]
                public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
                {
                        return Ok(await _context.Users.ToListAsync());
                }

        }
}
