using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class BlogPostsGet
    {
        private readonly ILogger _logger;
        private readonly IBloggerData _bloggerData;

        public BlogPostsGet(IBloggerData bloggerData, ILoggerFactory loggerFactory)
        {

            _logger = loggerFactory.CreateLogger<BlogPostsGet>();
            _bloggerData = bloggerData;
        }

        [Function("BlogPostsGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "blogPosts")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var blogPosts = await _bloggerData.GetBlogPosts();

            return new OkObjectResult(blogPosts);
        }
    }
}
