using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleBlogBusinessLayer.Interfaces;
using SampleBlogModels.BaseModels;
using SampleBlogModels.Models;
using Serilog;

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
        // GET: api/Blog/allposts
        [HttpGet("allposts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            //  The return type of Task<ActionResult> allows us to return status code 200 OK along with the list of invoices
            //  or status code 500 if there is a server error retrieving data from the database.
            try
            {
                // Use our created Method from repository and return a 200 Ok status code
                return Ok(await _blogService.GetAllPosts());
            }
            catch (CustomErrorException ex)
            {
                return BadRequest(ex.Message); // Return custom error message to the client
            }
            catch (Exception ex)
            {
                Log.Error($"Error retrieving data from the database: {ex.StackTrace} ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Blog/categories
        [HttpPost("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Post([FromBody] Category category)
        {
            try
            {
                return Ok(await _blogService.InsertCategory(category));
            }
            catch (CustomErrorException ex)
            {
                return BadRequest(ex.Message); // Return custom error message to the client
            }
            catch (Exception ex)
            {
                Log.Error($"Error inserting data from the database: {ex.StackTrace} ");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error inserting data from the database");
            }
        }
    }
}
