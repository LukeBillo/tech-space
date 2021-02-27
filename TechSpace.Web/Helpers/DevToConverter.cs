using System;
using TechSpace.DevTo.Models;
using TechSpace.Web.Models;

namespace TechSpace.Web.Helpers
{
    internal static class DevToConverter
    {
        public static Post DevToArticleToTechnologySpacePost(Article article)
        {
            return new Post
            {
                Id = article.Id.ToString(),
                Author = article.User.Name,
                Content = article.Description,
                Title = article.Title,
                Provider = FeedProvider.DevTo
            };
        }
    }
}