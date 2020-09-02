using System.Threading.Tasks;
using Refit;
using TechSpace.Reddit.Models;

namespace TechSpace.Reddit
{
    public interface IRedditApi
    {
        [Get("/r/{subreddit}/{filter}")]
        Task<RedditGeneric> GetSubredditPosts(string subreddit, string filter);
    }
}