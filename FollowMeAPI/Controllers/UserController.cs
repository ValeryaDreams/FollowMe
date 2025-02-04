using FollowMeAPI.Data;
using FollowMeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMeAPI.Controllers
{
        [Route("[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
                private readonly FollowMeContext _context;

                public  UserController(FollowMeContext context)
                {
                        _context = context;
                }

                [HttpGet]
                public async Task<ActionResult<IEnumerable<User>>> GetUsers()
                {
                        return await _context.User.ToListAsync();
                }
                
        }
}
