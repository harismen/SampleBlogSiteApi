using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using SampleBlogDatabaseCore;
using SampleBlogDatabaseLayer.Interfaces;
using SampleBlogModels.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleBlogDatabaseLayer.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly SampleBlogDbContext _context;

        public BlogRepository(SampleBlogDbContext context)
        {
            _context = context;
        }
        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<int> InsertCategory(Category category)
        {
            try
            {
                SqlParameter nameParam = new SqlParameter("@Name", category.Name);
                SqlParameter createdDateParam = new SqlParameter("@CreatedDate", DateTime.Now);
                SqlParameter isActiveParam = new SqlParameter("@IsActive", category.IsActive);
                SqlParameter isDeletedParam = new SqlParameter("@IsDeleted", category.IsDeleted);

                var result = await _context.Database.ExecuteSqlRawAsync("EXEC InsertCategory @Name, @CreatedDate, @IsActive, @IsDeleted",
                                nameParam, createdDateParam, isActiveParam, isDeletedParam);
                if (result < 0) 
                {
                    Log.Error($"Something went wrong trying to insert Category. SP Result: {result}");
                }
                else
                {
                    Log.Information($"Successfully inserted Category {category.Name}.");
                }
                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, "Database Error on Category insertion");
                throw;
            }
        }
    }
}
