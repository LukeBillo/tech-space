using System.Text.Json.Serialization;

namespace TechSpace.Web.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PassthroughUrl { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FeedProvider Provider { get; set; }
        
    }
}