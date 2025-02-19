using FollowMeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FollowMeAPI.Data
{
        public class FollowMeContext : DbContext
        {
                public DbSet<User> Users { get; set; }
                public DbSet<Post> Posts { get; set; }

                public FollowMeContext(DbContextOptions<FollowMeContext> options)
                        : base(options)
                {
                        Database.EnsureCreated();
                }
        }
}


