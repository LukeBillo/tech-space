using TechSpace.Domain;
using TechSpace.Reddit.Models;

namespace TechSpace.Helpers
{
    public static class RedditConverter
    {
        public static TechnologySpacePost RedditPostToTechnologySpacePost(Post redditPost)
        {
            var content = string.IsNullOrEmpty(redditPost.SelfText) ? redditPost.SelfTextHtml : redditPost.SelfText;
            
            return new TechnologySpacePost
            {
                Author = redditPost.Author,
                Title = redditPost.Title,
                Content = content,
                UrlLink = redditPost.Url,
                Source = FeedProvider.Reddit
            };
        }
    }
}