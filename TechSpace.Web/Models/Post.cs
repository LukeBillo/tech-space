using System.Text.Json.Serialization;

namespace TechSpace.Web.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string SpaceId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlLink { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FeedProvider Source { get; set; }
        
    }
}