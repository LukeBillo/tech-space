using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using TechSpace.Reddit.Models;

namespace TechSpace.Reddit
{
    public interface IRedditClient
    {
        Task<List<Post>> GetSubredditPosts(string subredditName, PostFilter postFilter);
    }

    public class RedditClient : IRedditClient
    {
        private readonly IRedditApi _redditApi;

        public RedditClient(HttpClient redditHttpClient)
        {
            _redditApi = RestService.For<IRedditApi>(redditHttpClient);
        }

        public async Task<List<Post>> GetSubredditPosts(string subredditName, PostFilter postFilter)
        {
            var posts = await _redditApi.GetSubredditPosts(subredditName, postFilter);
            return posts.ToListing()
                .Children
                .Select(child => child.ToPost())
                .ToList();
        }
    }
}