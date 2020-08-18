namespace TechSpace.Reddit.Filters
{
    public class WhereFilter
    {
        public PostFilter PostFilter { get; }
    }

    public enum PostFilter
    {
        Hot,
        New,
        Random,
        Rising,
        Top,
        Controversial
    }
}