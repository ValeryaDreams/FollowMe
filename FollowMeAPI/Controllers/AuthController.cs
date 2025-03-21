using FollowMeAPI.Data;
using FollowMeAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FollowMeAPI.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : Controller
        {
                private readonly FollowMeContext _context;

                public AuthController(FollowMeContext context)
                {
                        _context = context;
                }

                [HttpPost("login")]
                public IActionResult Login([FromBody] User model)
                {
                        var user = _context.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                        if (user != null)
                        {
                                return Ok(new {user.Id, user.Login, Success = true });
                        }
                        else
                        {
                                return Unauthorized();
                        }
                }
        }
}
