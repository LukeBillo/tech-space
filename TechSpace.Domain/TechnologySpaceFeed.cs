namespace TechSpace.Domain
{
    public class TechnologySpaceFeed
    {
        public FeedProvider Provider { get; set; }
        public FeedConnection Connection { get; set; }
    }

    public class FeedConnection
    {
        public string Name { get; set; }
        public string Resource { get; set; }
    }
}