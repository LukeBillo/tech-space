namespace TechSpace.Reddit.DependencyInjection
{
    public class RedditOptions
    {
        public string BaseUrl { get; set; } = "https://api.reddit.com";
        public string Secret { get; set; }
    }
}