using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSpace.Data;
using TechSpace.DevTo;
using TechSpace.DevTo.Models;
using TechSpace.Reddit;
using TechSpace.Web.Helpers;
using TechSpace.Web.Models;
using RedditPost = TechSpace.Reddit.Models.Post;
using Post = TechSpace.Web.Models.Post;
using RedditPostFilter = TechSpace.Reddit.Models.PostFilter;

namespace TechSpace.Web.Services
{
    public interface IPostsService
    {
        Task<List<Post>> GetPopularPostsForSpace(Space space);
        Task<Post> GetPostsById(string id, FeedProvider provider);
    }

    public class PostsService : IPostsService
    {
        private readonly IRedditClient _redditClient;
        private readonly IDevToClient _devToClient;
        private readonly ITechSpaceFeedRepository _spaceFeedRepository;

        public PostsService(IRedditClient redditClient, IDevToClient devToClient, ITechSpaceFeedRepository spaceFeedRepository)
        {
            _redditClient = redditClient;
            _devToClient = devToClient;
            _spaceFeedRepository = spaceFeedRepository;
        }
        
        public async Task<List<Post>> GetPopularPostsForSpace(Space space)
        {
            var redditPosts = GetRedditPostsForSpace(space, RedditPostFilter.Hot);
            var devToPosts = GetDevToPostsForSpace(space);

            return (await Task.WhenAll(redditPosts, devToPosts))
                .SelectMany(listOfPosts => listOfPosts)
                .ToList();
        }

        public async Task<Post> GetPostsById(string id, FeedProvider provider) => provider switch
        {
            FeedProvider.Reddit => RedditConverter.RedditPostToTechnologySpacePost(await GetRedditPost(id)),
            FeedProvider.DevTo => DevToConverter.DevToArticleToTechnologySpacePost(await GetDevToArticle(id)),
            _ => throw new ArgumentOutOfRangeException(nameof(provider), provider, $"Failed to get post - unknown provider: {provider}")
        };

        private async Task<RedditPost> GetRedditPost(string id)
        {
            return await _redditClient.GetPostById(id);
        }

        private Task<Article> GetDevToArticle(string id) => _devToClient.GetArticleById(id);

        private async Task<List<Post>> GetRedditPostsForSpace(Space space, RedditPostFilter postFilter)
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
            var posts = new List<Article>();

            foreach (var devToFeed in devToFeeds)
            {
                var articlesForTag = await _devToClient.GetArticles(new GetArticleQueryParams
                {
                    Top = 1,
                    ArticlesPerPage = 10,
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