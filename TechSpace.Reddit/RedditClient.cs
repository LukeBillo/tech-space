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
        Task<List<Post>> GetSubredditPosts(string subreddit, PostFilter postFilter);
        Task<Post> GetPostById(string id);
    }

    public class RedditClient : IRedditClient
    {
        private readonly IRedditApi _redditApi;

        public RedditClient(HttpClient redditHttpClient)
        {
            _redditApi = RestService.For<IRedditApi>(redditHttpClient);
        }

        public async Task<List<Post>> GetSubredditPosts(string subreddit, PostFilter postFilter)
        {
            var posts = await _redditApi.GetSubredditPosts(subreddit, postFilter);
            return posts.ToListing()
                .Children
                .Select(child => child.ToPost())
                .ToList();
        }

        public async Task<Post> GetPostById(string id)
        {
            var post = await _redditApi.SearchListings(new SearchParams { Id36 = id });
            return post.ToListing()
                .Children
                .Select(child => child.ToPost())
                .FirstOrDefault();
        }
    }
}