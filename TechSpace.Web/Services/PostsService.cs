using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSpace.DevTo;
using TechSpace.DevTo.Models;
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
        private readonly IDevToClient _devToClient;

        public PostsService(IRedditClient redditClient, IDevToClient devToClient)
        {
            _redditClient = redditClient;
            _devToClient = devToClient;
        }
        
        public async Task<List<Post>> GetPopularPostsForSpace(Space space)
        {
            var redditPosts = GetRedditPostsForSpace(space, PostFilter.Hot);
            var devToPosts = GetDevToPostsForSpace(space);

            return (await Task.WhenAll(redditPosts, devToPosts))
                .SelectMany(list => list)
                .ToList();
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

        private async Task<List<Post>> GetDevToPostsForSpace(Space space)
        {
            var devToFeeds = space.Feeds.Where(feed => feed.Provider == FeedProvider.DevTo);
            var posts = new List<DevToArticle>();

            foreach (var devToFeed in devToFeeds)
            {
                var articlesForTag = await _devToClient.GetArticles(new GetArticleQueryParams
                {
                    Top = 1,
                    Tag = devToFeed.Connection.Resource
                });

                posts.AddRange(articlesForTag);
            }

            return posts
                .Select(DevToConverter.DevToArticleToTechnologySpacePost)
                .ToList();
        }
    }
}