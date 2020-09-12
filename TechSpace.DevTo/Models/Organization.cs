using Newtonsoft.Json;

namespace TechSpace.DevTo.Models
{
    public class Organization
    {
        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("username")] 
        public string Username { get; set; }

        [JsonProperty("slug")] 
        public string Slug { get; set; }

        [JsonProperty("profile_image")] 
        public string ProfileImage { get; set; }

        [JsonProperty("profile_image_90")] 
        public string ProfileImage90 { get; set; }
    }
}