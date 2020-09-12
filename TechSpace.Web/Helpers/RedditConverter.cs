using TechSpace.Web.Models;
using Post = TechSpace.Web.Models.Post;

namespace TechSpace.Web.Helpers
{
    public static class RedditConverter
    {
        public static Post RedditPostToTechnologySpacePost(Reddit.Models.Post redditPost)
        {
            var content = string.IsNullOrEmpty(redditPost.SelfText) ? redditPost.SelfTextHtml : redditPost.SelfText;
            
            return new Post
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