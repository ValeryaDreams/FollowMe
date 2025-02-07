
using FollowMeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FollowMeAPI
{
        public class Program
        {
                public static void Main(string[] args)
                {
                        var builder = WebApplication.CreateBuilder(args);

                        // CORS Policy
                        builder.Services.AddCors(options =>
                        {
                                options.AddPolicy("MyPolicy",
                                    policy =>
                                    {
                                            policy.WithOrigins("https://followme-app-build.onrender.com/")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                                    });

                                options.AddPolicy("AnotherPolicy",
                                    policy =>
                                    {
                                            policy.WithOrigins("http://www.contoso.com")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                                    });
                        });


                        // Add services to the container.

                        builder.Services.AddControllers(); 
                        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                        builder.Services.AddEndpointsApiExplorer();
                        builder.Services.AddSwaggerGen();

                        // Connectings....
                        var connString = builder.Configuration.GetConnectionString("DefaultConnection");
                        builder.Services.AddDbContext<FollowMeContext>(opt => opt.UseSqlServer(connString));

                        var app = builder.Build();

                        // Configure the HTTP request pipeline.
                        if (app.Environment.IsDevelopment())
                        {
                                app.UseSwagger();
                                app.UseSwaggerUI();
                        }

                        app.UseHttpsRedirection();

                        app.UseCors();
                       
                        app.UseAuthorization();

                        app.MapControllers();

                        app.Run();
                }
        }
}
