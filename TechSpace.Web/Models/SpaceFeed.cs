using System;
using TechSpace.Data.Models;

namespace TechSpace.Web.Models
{
    public class SpaceFeed
    {
        public SpaceFeed() {}

        public SpaceFeed(SpaceFeedRow row)
        {
            Provider = Enum.Parse<FeedProvider>(row.FeedProvider);
            Connection = new FeedConnection
            {
                Name = row.Name,
                Resource = row.Resource
            };
        }
        
        public FeedProvider Provider { get; set; }
        public FeedConnection Connection { get; set; }
    }

    public class FeedConnection
    {
        public string Name { get; set; }
        public string Resource { get; set; }
    }
}