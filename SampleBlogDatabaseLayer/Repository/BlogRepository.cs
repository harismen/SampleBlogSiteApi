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
    }
}
