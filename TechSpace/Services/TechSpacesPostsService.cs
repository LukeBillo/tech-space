using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechSpace.Domain;
using TechSpace.Helpers;
using TechSpace.Reddit;
using TechSpace.Reddit.Filters;
using TechSpace.Reddit.Models;

namespace TechSpace.Services
{
    public interface ITechSpacesPostsService
    {
        Task<List<TechnologySpacePost>> GetPopularPostsForSpace(TechnologySpace space);
    }

    public class TechSpacesPostsService : ITechSpacesPostsService
    {
        private readonly IRedditService _redditService;

        public TechSpacesPostsService(IRedditService redditService)
        {
            _redditService = redditService;
        }
        
        public async Task<List<TechnologySpacePost>> GetPopularPostsForSpace(TechnologySpace space)
        {
            var redditPosts = await GetRedditPostsForSpace(space, PostFilter.Hot);
            return redditPosts;
        }

        private async Task<List<TechnologySpacePost>> GetRedditPostsForSpace(TechnologySpace space, PostFilter postFilter)
        {
            var redditFeeds = space.Feeds.Where(feed => feed.Provider == FeedProvider.Reddit);
            var posts = new List<Post>();
            
            foreach (var redditFeed in redditFeeds)
            {
                var postsForSubReddit = await _redditService.GetPostsForSubreddit(redditFeed.Connection.Resource, postFilter);
                posts.AddRange(postsForSubReddit);
            }

            return posts
                .Select(RedditConverter.RedditPostToTechnologySpacePost)
                .ToList();
        }
    }
}