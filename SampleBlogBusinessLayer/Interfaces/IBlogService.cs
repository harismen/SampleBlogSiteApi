﻿using SampleBlogModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogBusinessLayer.Interfaces
{
    public interface IBlogService
    {
        Task<List<Post>> GetAllPosts();
    }
}
