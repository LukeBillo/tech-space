using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using TechSpace.Reddit.Filters;
using TechSpace.Reddit.Models;

namespace TechSpace.Reddit
{
    public interface IRedditService
    {
        Task<List<Post>> GetPostsForSubreddit(string subredditName, PostFilter postFilter);
    }

    public class RedditService : IRedditService
    {
        private const string RedditBaseUrl = "https://www.reddit.com";

        public RedditService() {}

        public async Task<List<Post>> GetPostsForSubreddit(string subredditName, PostFilter postFilter)
        {
            var filter = postFilter.ToString("G").ToLowerInvariant();
            var postsApiUrl = RedditBaseUrl.AppendPathSegment("r")
                .AppendPathSegment(subredditName)
                .AppendPathSegment($"{filter}.json");
            
            var genericData = await postsApiUrl.GetJsonAsync<RedditGeneric>();
            var posts = genericData.ToListing().Children.Select(child => child.ToPost());
            
            return posts.ToList();
        }
    }
}