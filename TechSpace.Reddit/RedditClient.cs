using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using TechSpace.Reddit.Filters;
using TechSpace.Reddit.Models;

namespace TechSpace.Reddit
{
    public interface IRedditClient
    {
        Task<List<Post>> GetSubredditPosts(string subredditName, PostFilter postFilter);
    }

    public class RedditClient : IRedditClient
    {
        private const string RedditApiBaseUrl = "https://www.reddit.com";
        private readonly IRedditApi _redditApi;

        public RedditClient()
        {
            _redditApi = RestService.For<IRedditApi>(RedditApiBaseUrl);
        }

        public async Task<List<Post>> GetSubredditPosts(string subredditName, PostFilter postFilter)
        {
            var filter = postFilter.ToString("G").ToLowerInvariant();
            var posts = await _redditApi.GetSubredditPosts(subredditName, $"{filter}.json");

            return posts.ToListing()
                .Children
                .Select(child => child.ToPost())
                .ToList();
        }
    }
}