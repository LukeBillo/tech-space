namespace TechSpace.Reddit.DependencyInjection
{
    public class RedditOptions
    {
        public readonly string BaseUrl = "https://www.reddit.com";
        public string Secret { get; set; }
    }
}