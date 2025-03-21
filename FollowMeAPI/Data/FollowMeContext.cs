using FollowMeAPI.Models.Domain;
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

                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                        modelBuilder.Entity<Post>()
                                .HasOne(p => p.User)
                                .WithMany()
                                .HasForeignKey(p => p.UserId)
                                .OnDelete(DeleteBehavior.SetNull);

                        modelBuilder.Entity<Post>()
                                .Property(x => x.Date)
                                .HasDefaultValueSql("getdate()");
                        modelBuilder.Entity<Post>()
                                .Property(x => x.isGroup)
                                .HasDefaultValueSql("0");

                       
                }
        }
}

