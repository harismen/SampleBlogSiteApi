using Microsoft.EntityFrameworkCore;
using SampleBlogBusinessLayer.Interfaces;
using SampleBlogBusinessLayer.Services;
using SampleBlogDatabaseCore;
using Serilog;

namespace SampleBlogSiteApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            Log.Information("Starting up");
            try
			{
                var builder = WebApplication.CreateBuilder(args);

                // Configure Serilog
                builder.Host.UseSerilog((ctx, lc) => lc
                    .WriteTo.Console()
                    .ReadFrom.Configuration(ctx.Configuration));

                // Add services to the container.
                builder.Services.AddDbContext<SampleBlogDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("SampleBlogDbConnection"));
                });

                builder.Services.AddScoped<IBlogService, BlogService>();

                builder.Services.AddCors(o => {
                    o.AddPolicy("AllowAll", builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition"));
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

                app.UseCors("AllowAll");

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
			catch (Exception ex)
			{
                Log.Fatal(ex, "Unhandled exception");
			}
            finally
            {
                Log.Information("Shut down complete");
                Log.CloseAndFlush();
            }
        }
    }
}
