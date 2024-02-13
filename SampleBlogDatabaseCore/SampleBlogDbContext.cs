using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleBlogModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogDatabaseCore
{
    public class SampleBlogDbContext : DbContext
    {
        public SampleBlogDbContext() : base() { }

        public SampleBlogDbContext(DbContextOptions options) : base(options)
        {

        }

        static IConfigurationRoot _configuration;

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // Stored Procedures


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var builder = new ConfigurationBuilder()
                //                    .SetBasePath(Directory.GetCurrentDirectory())
                //                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //_configuration = builder.Build();
                //var cnstr = _configuration.GetConnectionString("SampleBlogDbConnection");
                optionsBuilder.UseSqlServer("Data Source=CS880;Database=SampleBlogDB;Integrated Security=True; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Initial MockData

            modelBuilder.Entity<Post>().HasData(
                new { Id = 1, CreatedDate = new DateTime(2024, 01, 01), IsActive = true, IsDeleted = false, Title = "Sample Post 1", Summary = "Mock created Post - 1", Content = "Automatically Created Post for Visualization Purposes"},
                new { Id = 2, CreatedDate = new DateTime(2024, 01, 01), IsActive = true, IsDeleted = false, Title = "Sample Post 2", Summary = "Mock created Post - 2", Content = "Automatically Created Post for Visualization Purposes" },
                new { Id = 3, CreatedDate = new DateTime(2024, 01, 01), IsActive = true, IsDeleted = false, Title = "Sample Post 3", Summary = "Mock created Post - 3", Content = "Automatically Created Post for Visualization Purposes" }
            );

            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, CreatedDate = new DateTime(2024, 01, 01), IsActive = true, IsDeleted = false, Name = "MOCKED" }
            );

        }
    }
}
