using TechSpace.DevTo.Models;
using TechSpace.Web.Models;

namespace TechSpace.Web.Helpers
{
    internal static class DevToConverter
    {
        public static Post DevToArticleToTechnologySpacePost(DevToArticle devToArticle)
        {
            return new Post
            {
                Id = devToArticle.Id.ToString(),
                Author = devToArticle.User.Name,
                Content = devToArticle.Description,
                Source = FeedProvider.DevTo,
                Title = devToArticle.Title,
                UrlLink = devToArticle.Url
            };
        }
    }
}