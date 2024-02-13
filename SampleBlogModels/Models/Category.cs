using SampleBlogModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogModels.Models
{
    public class Category : FullAuditModel
    {
        [Required]
        [MinLength(Constants.MIN_NAME)]
        [MaxLength(Constants.MAX_NAME)]
        public string Name { get; set; }
    }
}
