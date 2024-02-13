using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogModels.BaseModels
{
    /// <summary>
    /// OUR MODELS RESTRICTIONS FOR TABLE AND DB CREATION
    /// </summary>
    public class Constants
    {
        public const int MIN_NAME = 2;
        public const int MAX_NAME = 100;

        public const int MIN_SUMMARY_LENGTH = 10;
        public const int MAX_SUMMARY_LENGTH = 100;

        public const int MIN_POST_LENGTH = 10;
        public const int MAX_POST_LENGTH = 500;

        public const int MIN_COMMENT_LENGTH = 10;
        public const int MAX_COMMENT_LENGTH = 200;
    }
}
