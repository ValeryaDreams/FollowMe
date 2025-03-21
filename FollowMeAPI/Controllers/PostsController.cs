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
        public class PostsController : ControllerBase
        {
                private readonly FollowMeContext _context;

                public PostsController(FollowMeContext context)
                {
                        _context = context;
                }

                [HttpGet]
                [Route("GetAllPosts")]
                public async Task<ActionResult<IEnumerable<Post>>> AllPosts()
                {
                        return Ok(await _context.Posts.ToListAsync());
                }

                [HttpGet("{id}")]               
                public async Task<ActionResult<IEnumerable<Post>>> PostById(int id)
                {
                        var post = await _context.Posts.FirstOrDefaultAsync(p=> p.Id == id);
                        if (post == null)
                        {
                                return BadRequest("Can not find this post to CREATE");
                        }
                        return Ok(post);
                }

                [HttpPost]
                [Route("CreatePost")]
                public async Task<ActionResult<Post>> CreatePost([FromBody] AddPostRequestDTO request)
                {
                        // Проверяем, указан ли UserId
                        if (request.UserId.HasValue)
                        {
                                // Проверяем, существует ли пользователь с таким UserId
                                var user = await _context.Users.FindAsync(request.UserId.Value);
                                if (user == null)
                                {
                                        return NotFound($"Пользователь с ID {request.UserId} не найден.");
                                }
                        }

                        // Создаем объект Post
                        var post = new Post
                        {
                                Date = request.Date,
                                Text = request.Text,
                                isGroup = request.isGroup,
                                UserId = request.UserId // Устанавливаем связь с пользователем, если указан UserId
                        };

                        // Добавляем пост в базу данных
                        _context.Posts.Add(post);
                        await _context.SaveChangesAsync();

                        return Ok(post);
                }



                [HttpPut("{id}")]          
                public void UpdatePost(int id, [FromBody] string value)
                {

                }

                [HttpDelete("{id}")]
                public async Task<ActionResult<IEnumerable<Post>>> DeletePost(int id)
                {
                        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
                        if (post == null)
                        {
                                return BadRequest("Can not find this post to DELETE");
                        }

                        _context.Posts.Remove(post);
                        await _context.SaveChangesAsync();

                        return Ok("The post has been deleted");
                }

        }
}