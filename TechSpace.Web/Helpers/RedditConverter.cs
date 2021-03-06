﻿using TechSpace.Web.Models;
using Post = TechSpace.Web.Models.Post;

namespace TechSpace.Web.Helpers
{
    public static class RedditConverter
    {
        public static Post RedditPostToTechnologySpacePost(Reddit.Models.Post redditPost)
        {
            var content = string.IsNullOrEmpty(redditPost.SelfText) ? redditPost.SelfTextHtml : redditPost.SelfText;
            var kind = EnumHelpers.GetEnumMemberValue(redditPost.Kind);
            
            return new Post
            {
                Id = $"{kind}_{redditPost.Id}",
                Author = redditPost.Author,
                Title = redditPost.Title,
                Content = content,
                PassthroughUrl = redditPost.Url,
                Provider = FeedProvider.Reddit,
            };
        }
    }
}