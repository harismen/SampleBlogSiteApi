using Microsoft.EntityFrameworkCore;
using SampleBlogBusinessLayer.Interfaces;
using SampleBlogDatabaseCore;
using SampleBlogDatabaseLayer.Interfaces;
using SampleBlogDatabaseLayer.Repository;
using SampleBlogModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogBusinessLayer.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(SampleBlogDbContext _context)
        {
            _blogRepository = new BlogRepository(_context);
        }
        public Task<List<Post>> GetAllPosts()
        {
            return _blogRepository.GetAllPosts();
        }

        public Task<int> InsertCategory(Category category)
        {
            return _blogRepository.InsertCategory(category);
        }
    }
}
