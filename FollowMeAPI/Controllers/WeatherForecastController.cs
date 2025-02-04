using FollowMeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMeAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class WeatherForecastController : ControllerBase
        {
                private readonly ILogger<WeatherForecastController> _logger;
                private readonly IConfiguration _config;
                private readonly FollowMeContext _context;


                public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config, FollowMeContext usersContext)
                {
                        _logger = logger;
                        _config = config;
                        _context = usersContext;
                }

                [HttpGet(Name = "GetConfig")]
                public IActionResult Get()
                {
                        string connectionString = _config.GetConnectionString("DefaultConnection");
                        string token = _config.GetValue<string>("Token");
                        string port = _config.GetValue<string>("Port");

                        string res = $"ConnectionString: {connectionString}\n" +
                                $"Token: {token}\n" +
                                $"Port: {port}";

                        return Ok(res);
                }
        }
}
