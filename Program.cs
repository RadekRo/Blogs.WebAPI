using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Blogs.WebAPI.Infrastructure;

namespace Blogs.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<BlogsDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("BlogsDb"));
            options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
        });
        builder.Services.AddScoped<IBlogsRepository, BlogsRepository>();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            // WithOrigins("http://localhost:5173")
        });

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            // required to prevent "Self referencing loop detected" error
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors();

        app.MapControllers();

        app.Run();
    }
}