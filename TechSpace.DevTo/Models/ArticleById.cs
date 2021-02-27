using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TechSpace.DevTo.Models
{
    public class ArticleById
    {
        [JsonProperty("type_of")] 
        public string TypeOf { get; set; }

        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("title")] 
        public string Title { get; set; }

        [JsonProperty("description")] 
        public string Description { get; set; }

        [JsonProperty("cover_image")] 
        public string CoverImage { get; set; }

        [JsonProperty("readable_publish_date")]
        public string ReadablePublishDate { get; set; }

        [JsonProperty("social_image")] 
        public string SocialImage { get; set; }

        [JsonProperty("tag_list")] 
        public string TagList { get; set; }

        [JsonProperty("tags")] 
        public List<string> Tags { get; set; }

        [JsonProperty("slug")] 
        public string Slug { get; set; }

        [JsonProperty("path")] 
        public string Path { get; set; }

        [JsonProperty("url")] 
        public string Url { get; set; }

        [JsonProperty("canonical_url")] 
        public string CanonicalUrl { get; set; }

        [JsonProperty("comments_count")] 
        public int CommentsCount { get; set; }

        [JsonProperty("public_reactions_count")]
        public int PublicReactionsCount { get; set; }

        [JsonProperty("collection_id")] 
        public object CollectionId { get; set; }

        [JsonProperty("created_at")] 
        public DateTime CreatedAt { get; set; }

        [JsonProperty("edited_at")]
        public DateTime? EditedAt { get; set; }

        [JsonProperty("crossposted_at")] 
        public DateTime? CrosspostedAt { get; set; }

        [JsonProperty("published_at")] 
        public DateTime PublishedAt { get; set; }

        [JsonProperty("last_comment_at")] 
        public DateTime? LastCommentAt { get; set; }

        [JsonProperty("published_timestamp")] 
        public DateTime PublishedTimestamp { get; set; }

        [JsonProperty("user")] 
        public User User { get; set; }

        [JsonProperty("organization")] 
        public Organization Organization { get; set; }

        public Article ToArticle()
        {
            return new()
            {
                TypeOf = TypeOf,
                Id = Id,
                Title = Title,
                Description = Description,
                Organization = Organization,
                Path = Path,
                Slug = Slug,
                Tags = TagList,
                TagList = Tags,
                Url = Url,
                User = User,
                CanonicalUrl = CanonicalUrl,
                CollectionId = CollectionId,
                CommentsCount = CommentsCount,
                CoverImage = CoverImage,
                CreatedAt = CreatedAt,
                CrosspostedAt = CrosspostedAt,
                EditedAt = EditedAt,
                PublishedAt = PublishedAt,
                PublishedTimestamp = PublishedTimestamp,
                SocialImage = SocialImage,
                LastCommentAt = LastCommentAt,
                PublicReactionsCount = PublicReactionsCount,
                ReadablePublishDate = ReadablePublishDate
            };
        }
    }
}