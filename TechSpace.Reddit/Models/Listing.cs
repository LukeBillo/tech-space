using System.Collections.Generic;

namespace TechSpace.Reddit.Models
{
    public class Listing : RedditBaseData
    {
        public List<RedditGeneric> Children { get; set; }
    }
}