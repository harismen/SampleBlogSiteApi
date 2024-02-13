using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SampleBlogDatabaseCore;
using SampleBlogDatabaseLayer.Interfaces;
using SampleBlogModels.Models;
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

        public async Task InsertCategory(Category category)
        {
            //SqlParameter nameParam = new SqlParameter("@Name", category.Name);
            //SqlParameter posttIdParam = new SqlParameter("@DepartmentId", @PostId);
            //@Name, @PostId, @CreatedByUserId, @CreatedDate, @LastModifiedUserId, @LastModifiedDate, @IsActive, @IsDeleted

            //await _context.Database.ExecuteSqlRaw("EXEC InsertEmployee @Name, @DepartmentId", nameParam, departmentIdParam);
        }
    }
}
