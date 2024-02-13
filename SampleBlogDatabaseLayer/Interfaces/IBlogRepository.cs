using SampleBlogModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogDatabaseLayer.Interfaces
{
    public interface IBlogRepository
    {
        // Post Operations
        Task<List<Post>> GetAllPosts();

        // Category Operations
        Task<int> InsertCategory(Category category);
    }
}
