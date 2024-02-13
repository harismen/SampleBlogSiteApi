using SampleBlogModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogModels.Models
{
    public class Comment : FullAuditModel
    {
        [Required]
        [MinLength(Constants.MIN_COMMENT_LENGTH)]
        [MaxLength(Constants.MAX_COMMENT_LENGTH)]
        public string Content { get; set; }
        public int PostId { get; set; } // Parent post ID
    }
}
