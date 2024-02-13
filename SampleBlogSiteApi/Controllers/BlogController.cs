using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleBlogBusinessLayer.Interfaces;
using SampleBlogModels.Models;

namespace SampleBlogSiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("allposts")]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            //  The return type of Task<ActionResult> allows us to return status code 200 OK along with the list of invoices
            //  or status code 500 if there is a server error retrieving data from the database.
            try
            {
                // Use our created Method from repository and return a 200 Ok status code
                return Ok(await _blogService.GetAllPosts());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data from the database: {ex.StackTrace} ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
