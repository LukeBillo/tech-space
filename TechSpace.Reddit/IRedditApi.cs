using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TechSpace.Reddit.Models;

namespace TechSpace.Reddit
{
    [Headers("User-Agent: WebApp:TechSpace:v0.1 (by /u/crystelium)")]
    public interface IRedditApi
    {
        [Get("/r/{subreddit}/{filter}.json")]
        Task<RedditGeneric> GetSubredditPosts(string subreddit, PostFilter filter);

        [Get("/api/info")]
        Task<RedditGeneric> SearchListings([Query] SearchParams searchParams);
    }
}