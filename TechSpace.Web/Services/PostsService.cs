using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSpace.Reddit;
using TechSpace.Reddit.Models;
using TechSpace.Web.Helpers;
using TechSpace.Web.Models;
using RedditPost = TechSpace.Reddit.Models.Post;
using Post = TechSpace.Web.Models.Post;

namespace TechSpace.Web.Services
{
    public interface IPostsService
    {
        Task<List<Post>> GetPopularPostsForSpace(Space space);
    }

    public class PostsService : IPostsService
    {
        private readonly IRedditClient _redditClient;

        public PostsService(IRedditClient redditClient)
        {
            _redditClient = redditClient;
        }
        
        public async Task<List<Post>> GetPopularPostsForSpace(Space space)
        {
            var redditPosts = await GetRedditPostsForSpace(space, PostFilter.Hot);
            return redditPosts;
        }

        private async Task<List<Post>> GetRedditPostsForSpace(Space space, PostFilter postFilter)
        {
            var redditFeeds = space.Feeds.Where(feed => feed.Provider == FeedProvider.Reddit);
            var posts = new List<RedditPost>();
            
            foreach (var redditFeed in redditFeeds)
            {
                var postsForSubReddit = await _redditClient.GetSubredditPosts(redditFeed.Connection.Resource, postFilter);
                posts.AddRange(postsForSubReddit);
            }

            return posts
                .Select(RedditConverter.RedditPostToTechnologySpacePost)
                .ToList();
        }
    }
}