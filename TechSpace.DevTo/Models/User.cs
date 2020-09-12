using Newtonsoft.Json;

namespace TechSpace.DevTo.Models
{
    public class User
    {
        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("username")] 
        public string Username { get; set; }

        [JsonProperty("twitter_username")] 
        public string TwitterUsername { get; set; }

        [JsonProperty("github_username")] 
        public string GithubUsername { get; set; }

        [JsonProperty("website_url")] 
        public string WebsiteUrl { get; set; }

        [JsonProperty("profile_image")] 
        public string ProfileImage { get; set; }

        [JsonProperty("profile_image_90")] 
        public string ProfileImage90 { get; set; }
    }
}