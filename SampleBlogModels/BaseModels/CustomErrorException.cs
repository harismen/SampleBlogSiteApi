using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBlogModels.BaseModels
{
    /// <summary>
    /// Custom Error Base Class to Handle Business Logic and Validation Exceptions
    /// </summary>
    public class CustomErrorException : Exception
    {
        public CustomErrorException() : base()
        {
        }

        public CustomErrorException(string message) : base(message)
        {
        }

        public CustomErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
