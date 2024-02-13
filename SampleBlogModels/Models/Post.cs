using SampleBlogModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleBlogModels.Models
{
    public class Post : FullAuditModel
    {
        [Required]
        [MinLength(Constants.MIN_NAME)]
        [MaxLength(Constants.MAX_NAME)]
        public string Title { get; set; }
        [Required]
        [MinLength(Constants.MIN_SUMMARY_LENGTH)]
        [MaxLength(Constants.MAX_SUMMARY_LENGTH)]
        public string Summary { get; set; }
        [Required]
        [MinLength(Constants.MIN_POST_LENGTH)]
        [MaxLength(Constants.MAX_POST_LENGTH)]
        public string Content { get; set; }

        // Navigation properties
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
