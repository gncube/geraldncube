using Data;

namespace Api
{
    public interface IBloggerData
    {
        Task<BlogPost> AddBlogPost(BlogPost blogPost);
        Task<bool> DeleteBlogPost(int id);
        Task<IEnumerable<BlogPost>> GetBlogPosts();
        Task<BlogPost> UpdateBlogPost(BlogPost blogPost);
    }

    public class BloggerData : IBloggerData
    {
        private readonly List<BlogPost> blogPosts = new List<BlogPost>
        {
             new BlogPost
             {
                 Id = 10,
                    Name = "Strawberries",
                    Description = "16oz package of fresh organic strawberries",
                    Quantity = 1
             },
             new BlogPost
             {
                                 Id = 20,
                    Name = "Sliced bread",
                    Description = "Loaf of fresh sliced wheat bread",
                    Quantity = 1
             },
             new BlogPost
             {
                                 Id = 30,
                    Name = "Apples",
                    Description = "Bag of 7 fresh McIntosh apples",
                    Quantity = 1
             }

        };

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<BlogPost> AddBlogPost(BlogPost blogPost)
        {
            blogPost.Id = GetRandomInt();
            blogPosts.Add(blogPost);
            return Task.FromResult(blogPost);
        }

        public Task<bool> DeleteBlogPost(int id)
        {
            var index = blogPosts.FindIndex(p => p.Id == id);
            blogPosts.RemoveAt(index);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            return Task.FromResult(blogPosts.AsEnumerable());
        }

        public Task<BlogPost> UpdateBlogPost(BlogPost blogPost)
        {
            var index = blogPosts.FindIndex(p => p.Id == blogPost.Id);
            blogPosts[index] = blogPost;
            return Task.FromResult(blogPost);
        }
    }
}