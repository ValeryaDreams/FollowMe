using FollowMeAPI.Data;
using FollowMeAPI.Models;
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

                [HttpPost]
                [Route("CreateUser")]
                public async Task<ActionResult<IEnumerable<Post>>> CreateUser([FromBody] AddUserRequestDTO request)
                {
                        var user = new User
                        {
                                Id = Guid.NewGuid(),
                                Name = request.Name,
                                Login = request.Login,
                                Password = request.Password
                        };

                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();

                        return Ok(user);
                }

        }
}
